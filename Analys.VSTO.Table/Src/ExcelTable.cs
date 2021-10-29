using System;
using System.Collections.Generic;
using Analys.Types;
using Analys.VSTO.Types;
using Aryth;
using Typen;
using Veho.Matrix;
using Veho.Vector;

namespace Analys.VSTO {
  public class ExcelTable<T> : Table<T> {
    public Dictionary<string, (FieldType type, FieldStatus status)> FieldInfos =
      new Dictionary<string, (FieldType type, FieldStatus status)>();
    public Dictionary<string, string[]> StringColumns = new Dictionary<string, string[]>();
    public Dictionary<string, double[]> NumberColumns = new Dictionary<string, double[]>();
    public Dictionary<string, DateTime?[]> DateColumns = new Dictionary<string, DateTime?[]>();

    public new static ExcelTable<T> Build(string[] headLabels, T[,] matrix) {
      return new ExcelTable<T> {
        Head = headLabels,
        Rows = matrix,
      };
    }

    public static ExcelTable<T> FromOneBased(string[] headLabels, T[,] oneBased) {
      var (height, width) = oneBased.Size();
      var matrix = new T[height, width];
      var fieldTypes = new HashSet<FieldType>();
      var fieldInfos = new Dictionary<string, (FieldType type, FieldStatus status)>();
      for (int j = 0, jS = 1; j < width; j++, jS++) {
        for (var i = 0; i < height;) {
          var value = matrix[i, j] = oneBased[++i, jS];
          fieldTypes.Add(value.GetFieldType());
        }
        fieldInfos.Add(headLabels[j], fieldTypes.FieldInfo());
        fieldTypes.Clear();
      }
      return new ExcelTable<T> {
        Head = headLabels,
        Rows = matrix,
        FieldInfos = fieldInfos
      };
    }
    public bool TryLookupNumbers(string key, out double[] column) {
      if (this.NumberColumns.TryGetValue(key, out var numbers)) { column = numbers; } else if (
        this.TryLookup(key, out var elements)) {
        this.NumberColumns.Add(key, column = (elements as dynamic[]).Map(FieldTypeUtil.ParseToNumber));
      } else { column = null; }
      return column != null;
    }
    public bool TryLookupStrings(string key, out string[] column) {
      if (this.StringColumns.TryGetValue(key, out var strings)) { column = strings; } else if (
        this.TryLookup(key, out var elements)) {
        this.StringColumns.Add(key, column = (elements as dynamic[]).Map(FieldTypeUtil.ParseToString));
      } else { column = null; }
      return column != null;
    }
    public Crostab<double> NaiveCrostab((string side, string head, string formula) fields, Pivoted mode) {
      var sideSamples = this.TryLookupStrings(fields.side, out var sideElements) ? sideElements : null;
      var headSamples = this.TryLookupStrings(fields.head, out var headElements) ? headElements : null;
      var fieldSamples = this.TryLookupNumbers(fields.formula, out var fieldElements) ? fieldElements : null;
      if (sideSamples == null || headSamples == null || fieldSamples == null) return null;
      switch (mode) {
        case Pivoted.Count:
          return PivotFactory.Count().Record(sideSamples, headSamples, fieldSamples).ToCrostab(x => (double) x);
        case Pivoted.Sum: return PivotFactory.Sum().Record(sideSamples, headSamples, fieldSamples).ToCrostab();
        default: return PivotFactory.Build(mode).Record(sideSamples, headSamples, fieldSamples).ToCrostab(x => x.Value);
      }
    }
  }

  public class AlgebraicTable<T> : ExcelTable<T> {
    private readonly Dictionary<string, Crostab<double>> CrostabCollection = new Dictionary<string, Crostab<double>>();
    public Crostab<double> AlgebraicCrostab((string side, string head, string formula) fields, Pivoted mode) {
      if (ExpressionRegex.Operator.Match(fields.formula).Success) {
        var (side, head, formula) = fields;
        bool OperandParser(string field, out dynamic value) {
          var key = $"{mode.Label()}({field}) by {side} and {head}";
          if (double.TryParse(field, out var number)) { value = number; } 
          else if (this.CrostabCollection.TryGetValue(key, out var cached)) { value = cached; }
          else if (this.Has(field)) {
            // Console.WriteLine($">> value [side {side}, head {head}, field {field}] {mode}");
            // Console.WriteLine($">> [{key}] \n{current.Deco()}");
            CrostabCollection.Add(key, value = this.NaiveCrostab((side, head, field), mode));
          } else {
            value = null;
          }
          return value!=null;
        }
        var operatorParser =
          TryParserFactory.MakeMethodParser(typeof(Crostab<double>), typeof(double), typeof(System.Math));
        var calculator = AlgebraCalculator.Build(OperandParser, operatorParser);
        var result = calculator.Calculate(formula);
        return result as Crostab<double>;
      } else {
        return NaiveCrostab(fields, mode);
      }
    }
  }
}
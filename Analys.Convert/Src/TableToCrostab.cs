using System;
using Analys.Types;
using Veho.Tuple;
using Typen;
using Acc = Analys.Pivot.Struct.Accumulators;
using Init = Analys.Pivot.Struct.Initializers;

namespace Analys.Convert {
  public static class TableToCrostab {
    public static (int side, int head, int field) GetIndexes<T>(
      this Table<T> table,
      (string side, string head, string field) fields
    ) =>
      fields.Map(table.CoIn);

    public static Crostab<double> Crostab(
      this Table<object> table,
      (string side, string head, string field) fields,
      Pivoted mode,
      Func<object, double> parser = null
    ) {
      if (parser == null) parser = Numeral.CastDouble;
      var indexes = table.GetIndexes(fields);
      switch (mode) {
        case Pivoted.Count: return PivotFactory.Count(indexes).Record(table.Rows, parser).ToCrostab(x => (double)x);
        case Pivoted.Sum: return PivotFactory.Sum(indexes).Record(table.Rows, parser).ToCrostab();
        default: return PivotFactory.Build(indexes, mode).Record(table.Rows, parser).ToCrostab(x => x.Value);
      }
    }
  }
}
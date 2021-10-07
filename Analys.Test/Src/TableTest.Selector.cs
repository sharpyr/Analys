using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using NUnit.Framework;
using Spare;
using Veho;
using Veho.Vector;
using static System.Text.RegularExpressions.RegexOptions;
using Selectors = Veho.Rows.Selectors;

namespace Analys.Test {
  public static class Util {
    public static IEnumerable<T[]> IntoRowsIter2<T>(this Table<T> crostab, params Regex[] headLabels) {
      var indices = headLabels.Map(crostab.CoIn);
      indices.Deco().Says("indices");
      return Selectors.SelectRowsIntoIter(crostab.Rows, indices);
    }
  }

  [TestFixture]
  public class TableTest_Selector {
    [Test]
    public void AlphaTest() {
      var table = Table<int>.Build(
        Vec.From("foo", "bar", "zen"),
        (3, 4).Init((x, y) => x * 10 + y)
      );
      var labels = Vec.From("foo", "zen");
      foreach (var values in table.SelectRowsIntoIter(labels)) {
        var (foo, zen) = values.T2();
        Console.WriteLine($">> [foo] {foo} [bar] {zen}");
      }
    }


    [Test]
    public void BetaTest() {
      var table = Table<int>.Build(
        Vec.From("index", "Side", "headers", "Fields", "formula", "presets"),
        (6, 6).Init((x, y) => y)
      );
      table.Deco().Says("table");
      var regOpt = IgnoreCase | Compiled;
      var labelRegexes = Vec.From(
        new Regex(@"(banner|head(?:er)?)(?:s)?", regOpt),
        new Regex(@"(field|value)(?:s)?", regOpt),
        new Regex(@"(formula(?:e)?|value)(?:s)?", regOpt),
        new Regex(@"(colo(?:u)?r|preset)(?:s)?", regOpt),
        new Regex(@"comment", regOpt)
      );
      foreach (var values in table.IntoRowsIter2(labelRegexes)) {
        var (head, field, formula, preset, unknown) = values.T5();
        Console.WriteLine($">> head {head}, field {field}, formula {formula}, preset {preset} unknown {unknown}");
      }
    }
  }
}
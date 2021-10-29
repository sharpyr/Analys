using Analys.Test.Assets;
using Analys.Types;
using Analys.VSTO;
using NUnit.Framework;
using Spare;
using Veho;

namespace Analys.Test.Crostab {
  [TestFixture]
  public class AlgebraicTableTests {
    [Test]
    public void AlgebraicExcelTableTestAlpha() {
      var tableSpecs = Seq.From(
        ("date", "sid", "rev[a] / sold[a]", Pivoted.Sum),
        ("date", "sid", "rev[a]", Pivoted.Sum),
        ("date", "sid", "rev[a] / sold[a] * 100", Pivoted.Sum)
        // ("date", "sid", "rev[a] / no_exist * 100", Pivoted.Sum)
      );
      var table = TableCollection.FieldPerformanceTable.ToAlgebraicTable();
      foreach (var (side, head, formula, mode) in tableSpecs) {
        var crostab = table.AlgebraicCrostab((side, head, formula), mode);
        crostab.Deco().Says($"{mode}({formula}) by {side} and {head}");
      }
    }
  }
}
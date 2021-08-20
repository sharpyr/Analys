using Analys.Types;
using Mu = Analys.Mutable;
using NUnit.Framework;
using Spare;
using Typen;
using Veho;
using static System.Double;
using static Palett.Presets;
using Analys.Mutable;

namespace Analys.Test.Mutable {
  [TestFixture]
  public class CrostabTests {
    [Test]
    public void SimpleTest() {
      var table = Mu::Table<object>.Build(
        Seq.From("day", "name", "served", "sold", "adt"),
        Seq.From(
          Seq.From<object>(1, "Joyce", 70, 7, ""),
          Seq.From<object>(1, "Joyce", 66, 15, ""),
          Seq.From<object>(2, "Joyce", 86, 10, ""),
          Seq.From<object>(2, "Joyce", NaN, NaN, ""),
          Seq.From<object>(3, "Joyce", 96, 2, ""),
          Seq.From<object>(1, "Lance", 98, 15, ""),
          Seq.From<object>(1, "Lance", 66, 15, ""),
          Seq.From<object>(2, "Lance", 85, 12, ""),
          Seq.From<object>(2, "Lance", 63, 12, ""),
          Seq.From<object>(3, "Lance", NaN, NaN, ""),
          Seq.From<object>(1, "Naomi", 90, 14, ""),
          Seq.From<object>(1, "Naomi", 66, 9, ""),
          Seq.From<object>(2, "Naomi", NaN, NaN, ""),
          Seq.From<object>(2, "Naomi", 93, 16, ""),
          Seq.From<object>(3, "Naomi", 78, 8, "")
        )
      );
      var fields = ("name", "day", "sold");
      foreach (Pivoted mode in Enum<Pivoted>.Values) {
        var crostab = table.Crostab(fields, mode);
        crostab
          .ToCrostab()
          .Deco(presets: (Subtle, Fresh)).Says(mode.Label());
      }
    }
  }
}
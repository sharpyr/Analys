using NUnit.Framework;
using Spare;
using Veho;
using Veho.List;
using MU = Analys.Mutable;
using Analys.Mutable.LinearAlgebra;

namespace Analys.Test.Mutable {
  [TestFixture]
  public class PantoneOverlapTests {
    [Test]
    public void TestAlpha() {
      var rows = Seq.From(
        Seq.From(" ", " ", " ", " ", " ", " ", " ", "+", " ", " "),
        Seq.From(" ", " ", "+", " ", "+", " ", " ", " ", " ", " "),
        Seq.From(" ", "+", " ", " ", "+", " ", " ", " ", " ", " "),
        Seq.From(" ", " ", " ", " ", " ", " ", "+", " ", "+", " "),
        Seq.From(" ", "+", "+", " ", " ", " ", " ", " ", " ", " "),
        Seq.From(" ", " ", " ", " ", " ", " ", " ", " ", " ", " "),
        Seq.From(" ", " ", " ", "+", " ", " ", " ", " ", "+", " "),
        Seq.From("+", " ", " ", " ", " ", " ", " ", " ", " ", " "),
        Seq.From(" ", " ", " ", "+", " ", " ", "+", " ", " ", " "),
        Seq.From(" ", " ", " ", " ", " ", " ", " ", " ", " ", " ")
      );
      var labels = Seq.From(
        "S.Orange",
        "Peach.C",
        "C.Blush",
        "Turmeric",
        "Apricot.S",
        "Chamois",
        "B.M.gold",
        "Amber.Y",
        "Zinnia",
        "Sahara"
      );
      var crostab = MU.Crostab<string>.Build(labels.Map(x => x), labels.Map(x => x), rows);
      crostab.ToCrostab().Deco().Says("crostab");
      foreach (var diagonalBlock in crostab.IntersectionalBlocks("+")) {
        diagonalBlock.ToCrostab().Deco().Says("diagonal");
      }
    }
  }
}
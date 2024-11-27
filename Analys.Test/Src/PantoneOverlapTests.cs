using NUnit.Framework;
using Spare;
using Veho;
using Veho.Vector;

namespace Analys.Test {
  [TestFixture]
  public class PantoneOverlapTests {
    [Test]
    public void TestAlpha() {
      var rows = new[,] {
        { " ", " ", " ", " ", " ", " ", " ", "+", " ", " " },
        { " ", " ", "+", " ", "+", " ", " ", " ", " ", " " },
        { " ", "+", " ", " ", "+", " ", " ", " ", " ", " " },
        { " ", " ", " ", " ", " ", " ", "+", " ", "+", " " },
        { " ", "+", "+", " ", " ", " ", " ", " ", " ", " " },
        { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " },
        { " ", " ", " ", "+", " ", " ", " ", " ", "+", " " },
        { "+", " ", " ", " ", " ", " ", " ", " ", " ", " " },
        { " ", " ", " ", "+", " ", " ", "+", " ", " ", " " },
        { " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }
      };
      var labels = Vec.From(
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
      var crostab = Crostab<string>.Build(labels.Slice(), labels.Slice(), rows);
      crostab.Deco().Says("crostab");
      foreach (var diagonalBlock in crostab.IntersectionalBlocks("+")) {
        diagonalBlock.Deco().Says("diagonal");
      }
      crostab.SelectBy(Vec.From("Peach.C", "C.Blush", "Apricot.S", "Amber.Y"), Vec.From("Peach.C", "C.Blush", "Amber.Y")).Deco().Says("selected");
    }
  }
}
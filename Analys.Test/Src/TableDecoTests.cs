using NUnit.Framework;
using Palett.Presets;
using Spare.Logger;

namespace Analys.Test {
  [TestFixture]
  public class TableDecoTests {
    [Test]
    public void TableDecoTest() {
      var table = Table<object>.Build(
        new[] {"foo", "bar", "zen"},
        new object[,] {
          {1, "Tesla", 10},
          {2, "Faraday", 120},
          {3, "BYD", 1250}
        });
      table.Deco(presets: (PresetCollection.Planet, PresetCollection.Fresh)).Logger();
    }

    [Test]
    public void CrostabDecoTest() {
      var table = Crostab<object>.Build(
        new[] {"foo", "bar", "zen"},
        new[] {"foo", "bar", "zen"},
        new object[,] {
          {1, "Tesla", 10},
          {2, "Faraday", 120},
          {3, "BYD", 1250}
        });
      table.Deco(tab: 2, presets: (PresetCollection.Planet, PresetCollection.Fresh)).Logger();
    }
  }
}
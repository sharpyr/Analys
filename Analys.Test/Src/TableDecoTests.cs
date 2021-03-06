using NUnit.Framework;

namespace Analys.Test {
  [TestFixture]
  public class TableDecoTests {
    [Test]
    public void Test() {
      var table = Table<object>.Build(new[] {"foo", "bar", "zen"},
        new object[,] {
          {1, "Aa", 128},
          {2, "Bb", 256},
          {3, "Cc", 512}
        });
      // Analys.Decos.Deco().Logger();
    }
  }
}
using Analys.Stat.Population;
using NUnit.Framework;
using Spare;

namespace Analys.Test {
  [TestFixture]
  public class StructTest {
    [Test]
    public void TestAlpha() {
      var a = 0;
      a.ToText().Logger();
      var b = (1, 1);
      b.ToText().Logger();
      var c = new Avg { Sum = 0, Count = 5 };
      c.ToText().Logger();
      // var d = new List<string>();
      // d.toText().Logger();
    }
  }

  public static class StructTestsFunctions {
    public static string ToText<T>(this T value) where T : struct {
      return value.ToString();
    }
  }
}
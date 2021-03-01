using NUnit.Framework;
using Spare.Logger;

namespace Analys.Test {
  public class Tests {
    [SetUp]
    public void Setup() { }

    [Test]
    public void Test1() {
      (default(string[])?.ToString() ?? "null").Logger();
      default(double).Logger();
      default(int).Logger();
      Assert.Pass();
    }
  }
}
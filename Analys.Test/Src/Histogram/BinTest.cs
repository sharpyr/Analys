using System;
using Analys.Histogram;
using NUnit.Framework;

namespace Analys.Test.Histogram {


  [TestFixture]
  public class BinTest {
    [Test]
    public void Test() {
      var bin = (0.0, 100.0);
      double[] list = { -20, 0, 40, 60, 100, 120 };
      foreach (var d in list) {
        Console.WriteLine($">> [{d}] {bin.Allow(d)} {bin.Hold(d)}");
      }
    }
  }
}
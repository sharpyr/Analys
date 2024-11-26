using System;
using Analys.Histogram;
using NUnit.Framework;

namespace Analys.Test.Histogram {
  public static partial class Util {
    public static bool Hold<T>(this (T min, T max) bin, T value) where T : IComparable<T> {
      Console.WriteLine($">> [{bin.min} compare to {value}] {bin.min.CompareTo(value)} [{value} compare to {bin.max}] {value.CompareTo(bin.max)}");
      return bin.min.CompareTo(value) <= 0 && value.CompareTo(bin.max) <= 0;
    }
    public static bool Allow<T>(this (T min, T max) bin, T value) where T : IComparable<T> => bin.min.CompareTo(value) < 0 && value.CompareTo(bin.max) < 0;
  }

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
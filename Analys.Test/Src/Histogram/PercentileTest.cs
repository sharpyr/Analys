using System;
using System.Linq;
using Analys.Histogram;
using NUnit.Framework;
using Spare;
using Veho;
using Veho.Vector;
using static Aryth.Math;

namespace Analys.Test.Histogram {
  public static class Util {
    public static double Percentile(double[] vec, double percent) {
      Array.Sort(vec);
      var len = vec.Length;
      var ti = (len - 1) * percent + 1;
      if (AlmostEqual(ti, 1d, 0.0001)) return vec[0];
      if (AlmostEqual(ti, len, 0.0001)) return vec[len - 1];
      int k = (int)ti;
      double d = ti - k;
      return vec[k - 1] + d * (vec[k] - vec[k - 1]);
    }


    public static double PercentileRank(double[] vec, double value) {
      var n = vec.Length;
      var pr = (vec.Count(v => v < value) + 0.5 * vec.Count(v => AlmostEqual(v, value, 0.0001))) / n;
      return pr;
    }

    // public static (string, (double min, double max))[] PercentileIntervals(this double[] values, double[] percentiles) {
    //   percentiles = percentiles.Filter(x => (0d, 1d).Allow(x)).ToArray();
    //   if (percentiles.Length <= 0 || values.Length <= 0) return Vec.Iso(1, (string.Empty, (double.NaN, double.NaN)));
    //   if (percentiles.Length == 1) {
    //     
    //   }
    // }
  }

  [TestFixture]
  public class PercentileTest {
    [Test]
    public void TestPercentileRank() {
      // double[] raw = { 0, 40, 50, 60, 80, 90, 100 };
      double[] vec = { 80, 0, 40, 100, 60, 80, 90, };

      foreach (var v in vec) {
        Console.WriteLine($">> [{v}] percentile rank ({Util.PercentileRank(vec, v):n2})");
      }
    }
    [Test]
    public void Test() {
      double[] raw = { 0, 40, 50, 60, 80, 90, 100 };
      double[] vec = { 80, 0, 40, 100, 60, 50, 90, };
      var percentiles = Vec.From(0, 0.5, 0.8, 0.9, 1);
      var indexes = percentiles.Map(percentile => {
        var c = (vec.Length - 1) * percentile;
        Console.WriteLine($">> [c] {c}");
        for (var i = vec.Length - 1; i >= 0; i--) {
          if (i <= c) return i;
        }
        return -1;
      });
      Console.WriteLine($">> [indexes] {indexes.Deco()}");
      var percentileList = Vec.From(0, 3, 6);

      foreach (var percentile in percentileList) {
        Console.WriteLine($">> [{percentile}] th smallest element is ({vec.Smalldian(percentile)})");
      }
      // foreach (var d in vec) {
      //   Console.WriteLine($">> [{d}] {vec} {bin.Hold(d)}");
      // }
    }
  }
}
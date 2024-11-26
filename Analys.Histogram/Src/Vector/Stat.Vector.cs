using System;
using Analys.Histogram;
using Typen;
using Veho.Vector;

namespace Analys.Vector {
  public static partial class Stat {
    public static double Sq(this double x) => Math.Pow(x.ToNum(), 2);
    public static double Average<T>(this T[] vec) {
      var sum = vec.Fold((t, v) => t + v.ToNum(), 0d);
      return sum / vec.Length;
    }

    public static double Median<T>(this T[] vec) where T : IComparable<T> {
      if (vec.Length == 0) return double.NaN;
      if (vec.Length == 1) return vec[0].ToNum();
      return vec.Slice().Smalldian((vec.Length - 1) / 2).ToNum();
    }

    public static double StdDev<T>(this T[] vec) {
      if (vec.Length == 0) return 0;
      var avg = Average(vec);
      var sum = vec.Fold((t, v) => t + (v.ToNum() - avg).Sq(), 0d);
      return Math.Sqrt(sum / (vec.Length - 1));
    }
  }
}
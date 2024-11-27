using System;
using System.Collections.Generic;
using Analys.Histogram;
using Typen;
using Veho.Vector;

namespace Analys.Vector {
  public static partial class Stat {
    public static double Average<T>(this IReadOnlyList<T> vec) {
      var sum = vec.Fold((t, v) => t + v.ToNum(), 0d);
      return sum / vec.Count;
    }

    public static double Median<T>(this IReadOnlyList<T> vec) where T : IComparable<T> {
      if (vec.Count == 0) return double.NaN;
      if (vec.Count == 1) return vec[0].ToNum();
      return vec.Slice().Smalldian((vec.Count - 1) / 2).ToNum();
    }

    public static double StdDev<T>(this IReadOnlyList<T> vec) {
      if (vec.Count == 0) return 0;
      var avg = vec.Average();
      var sum = vec.Fold((t, v) => t + (v.ToNum() - avg).Sq(), 0d);
      return Math.Sqrt(sum / (vec.Count - 1));
    }
  }
}
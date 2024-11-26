using System;
using System.Collections.Generic;
using Veho.Vector;

// using static Generic.Math.GenericMath;

namespace Analys.Histogram {
  public static class Bins {
    public static IEnumerable<(T, T)> IntoBins<T>(params T[] intervals) where T : IComparable<T> {
      var sorted = intervals.Sort((a, b) => a.CompareTo(b));
      int i = 1, hi = sorted.Length;
      var prev = sorted[0];
      while (i < hi) {
        var curr = sorted[i++];
        yield return (prev, curr);
        prev = curr;
      }
    }

    // public static bool Equals<T>(this (T x, T y) a, (T x, T y) b) => Equal(a.x, b.x) && Equal(a.y, b.y);

    public static bool Equals<T>(this (T x, T y) a, (T x, T y) b) where T : IComparable<T> => a.x.CompareTo(b.x) == 0 && a.y.CompareTo(b.y) == 0;
    public static bool Hold<T>(this (T min, T max) bin, T value) where T : IComparable<T> => bin.min.CompareTo(value) <= 0 && value.CompareTo(bin.max) <= 0;
    public static bool Allow<T>(this (T min, T max) bin, T value) where T : IComparable<T> => bin.min.CompareTo(value) < 0 && value.CompareTo(bin.max) < 0;

    public static string ToStr<T>(this (T min, T max) bin, Open open = Open.None) {
      var lr = open.Decode();
      var a = lr.min ? '(' : '[';
      var b = lr.max ? ')' : ']';
      return $"{a}{bin.min}, {bin.max}{b}";
    }
  }
}
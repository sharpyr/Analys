using System;
using System.Collections.Generic;
using Veho.Enumerable;
using Veho.Vector;

namespace Analys.Histogram {
  /// <summary>
  /// Median computation, with code adopted from Introduction to Algorithms by Cormen et al., 3rd Ed.
  /// </summary>
  public static class Cormen {
    /// <summary>
    /// Partitions the given list around a pivot element such that all elements on left of pivot are <= pivot
    /// and the ones at thr right are > pivot. This method can be used for sorting, n-order statistics such as
    /// median finding algorithms.
    /// Pivot is selected randomly if random number generator is supplied,
    /// else it's selected as last element in the list.
    /// Reference: Introduction to Algorithms 3rd Ed., Corman et al., pp 171
    /// </summary>
    private static int Partition<T>(this IList<T> vec, int lo, int hi, Random rand = null) where T : IComparable<T> {
      if (rand != null) vec.Swap(hi, rand.Next(lo, hi + 1));
      var val = vec[hi];
      var pr = lo - 1;
      for (var i = lo; i < hi; i++)
        if (vec[i].CompareTo(val) <= 0)
          vec.Swap(i, ++pr);
      vec.Swap(hi, ++pr);
      return pr;
    }

    /// <summary>
    /// Returns n-th smallest (given by index) element from the list.
    /// n starts from 0. e.g. n = 0 returns minimum, n = 1 returns 2nd smallest element etc.
    /// Warning: input list would be mutated in the process.
    /// Reference: Introduction to Algorithms 3rd Edition, Corman et al., pp 216
    /// </summary>
    public static T Smalldian<T>(this IList<T> vec, int ind, Random rnd = null) where T : IComparable<T> {
      return Smalldian(vec, ind, 0, vec.Count - 1, rnd);
    }
    private static T Smalldian<T>(this IList<T> vec, int ind, int lo, int hi, Random rand) where T : IComparable<T> {
      while (true) {
        var i = vec.Partition(lo, hi, rand); // i = pivotIndex
        if (i == ind) return vec[i];
        if (i > ind) hi = i - 1;
        if (i < ind) lo = i + 1;
      }
    }

    //(i == j) check is not required but Partition function may make many calls so its for perf reason
    private static void Swap<T>(this IList<T> vec, int i, int j) {
      if (i != j) { (vec[i], vec[j]) = (vec[j], vec[i]); }
    }

    /// <summary>
    /// Warning: specified list would be mutated in the process.
    /// </summary>
    public static T Median<T>(this IList<T> vec) where T : IComparable<T> {
      return vec.Smalldian((vec.Count - 1) / 2);
    }

    public static double Median<T>(this IEnumerable<T> iter, Func<T, double> conv) {
      var vec = iter.Map(conv);
      return vec.Smalldian(vec.Hi() / 2);
    }
  }
}
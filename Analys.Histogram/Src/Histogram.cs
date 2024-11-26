using System;
using System.Collections.Generic;
using System.Linq;
using Analys.Histogram;
using Veho.Vector;
using static Analys.Histogram.Bins;

namespace Analys {
  public class Histogram<T> where T : IComparable<T> {
    public string[] Keys;
    public (T min, T max)[] Bins;
    public List<T>[] Rows;

    public static Histogram<T> Build(params T[] samples) {
      var bins = IntoBins(samples).ToArray();
      return new Histogram<T> { Bins = bins.ToArray(), Rows = bins.Map((i, _) => new List<T>()) };
    }

    public static Histogram<T> BuildPercentile(params T[] samples) {
      var bins = IntoBins(samples).ToArray();
      return new Histogram<T> { Bins = bins.ToArray(), Rows = bins.Map((i, _) => new List<T>()) };
    }

    public int Length => this.Bins.Length;
    public int Bound => this.Bins.GetUpperBound(0);
    public List<T> this[int i] => Rows[i];
    public List<T> this[(T, T) bin] {
      get {
        for (var i = 0; i < Bins.Length; i++)
          if (Bins[i].Equals(bin))
            return Rows[i];
        return null;
      }
    }

    public void Reset() { this.Rows.Iterate(row => row.Clear()); }

    public int Population => this.Rows.Fold((t, v) => t + v.Count, 0);

    public IEnumerable<((T min, T max) bin, List<T> vec)> IntoIter() {
      for (var i = 0; i < this.Length; i++) yield return (this.Bins[i], this.Rows[i]);
    }

    public IEnumerable<List<T>> IterRows() {
      for (var i = 0; i < this.Length; i++) yield return this.Rows[i];
    }

    public IEnumerable<(string, List<T>)> ToEntries() {
      for (int i = 0, hi = this.Bound; i <= hi; i++)
        yield return (this.Key(i), this.Rows[i]);
    }

    public string Key(int i) => this.Length > 0 ? this.Bins[i].ToStr(i == this.Bound ? Open.None : Open.Max) : "";

    public int Index(T v) {
      for (var i = this.Bound; i >= 0; i--)
        if (this.Bins[i].Hold(v))
          return i;
      return -1;
    }

    public Histogram<T> Add(T x) {
      var i = this.Index(x);
      if (i < 0) return this;
      this[i].Add(x);
      return this;
    }

    public Histogram<T> Add(params T[] arr) {
      foreach (var x in arr) { this.Add(x); }
      return this;
    }


    public static Histogram<T> operator +(Histogram<T> hg, T v) => hg.Add(v);

    public static Histogram<T> operator +(Histogram<T> hg, T[] v) => hg.Add(v);
  }
}
using System.Collections.Generic;

namespace Analys.Mutable.Pivot.Class {
  public static class Accumulators {
    public static List<T> Merge<T>(List<T> target, List<T> value) {
      if (value == null) return target;
      target.AddRange(value);
      return target;
    }
    public static List<T> Accum<T>(List<T> target, T value) {
      if (value == null) return target;
      target.Add(value);
      return target;
    }
  }
}
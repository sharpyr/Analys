using System;

namespace Analys.Types {
  public static class PivotPreset {
    public static (Func<T[]> init, Func<T[], T[], T[]> accum) Merge<T>() => (Inits.Merge<T>(), Accumulators.Merge<T>());
    public static (Func<T[]> init, Func<T[], T, T[]> accum) Accum<T>() => (Inits.Accum<T>(), Accumulators.Accum<T>());
    public static (Func<int> init, Func<int, int, int> accum) Count() => (Inits.Count(), Accumulators.Count());
    public static (Func<double> init, Func<double, double, double>accum) Incre() => (Inits.Incre(), Accumulators.Incre());
    public static (Func<double> init, Func<double, double, double>accum) Max() => (Inits.Max(), Accumulators.Max());
    public static (Func<double> init, Func<double, double, double>accum) Min() => (Inits.Min(), Accumulators.Min());
    public static (Func<object> init, Func<object, object, object>accum) First() => (Inits.First(), Accumulators.First());
    public static (Func<object> init, Func<object, object, object>accum) Last() => (Inits.Last(), Accumulators.Last());
    public static (Func<Average> init, Func<Average, double, Average>accum) Average() => (Inits.Average(), Accumulators.Average());
  }
}
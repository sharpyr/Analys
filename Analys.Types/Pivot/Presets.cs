using System;
using Analys.Types;
using Typen.Numeral;

namespace Analys.Pivot {
  public static class PivotExt {
    public static (dynamic init, dynamic accum, dynamic conv) ModeToPreset(this Pivoted mode) {
      switch (mode) {
        case Pivoted.Accum: return Presets.Accum<dynamic>();
        case Pivoted.Merge: return Presets.Accum<dynamic>();
        case Pivoted.Count: return Presets.Count<dynamic>();
        case Pivoted.Sum: return Presets.Sum<dynamic>();
        case Pivoted.Average: return Presets.Average<dynamic>();
        case Pivoted.Max: return Presets.Max<dynamic>();
        case Pivoted.Min: return Presets.Min<dynamic>();
        case Pivoted.First: return Presets.First<dynamic>();
        case Pivoted.Last: return Presets.Last<dynamic>();
        default: throw new ArgumentOutOfRangeException(nameof(mode), mode, "Invalid PivotMode");
      }
    }
  }

  public static class Presets {
    public static (Func<T[]> init, Func<T[], T[], T[]> accum, Func<T[], T[], T[]>conv) Merge<T>() => (Inits.Merge<T>(), Accumulators.Merge<T>(), null);
    public static (Func<T[]> init, Func<T[], T, T[]> accum, Func<T, T, T[]> conv) Accum<T>() => (Inits.Accum<T>(), Accumulators.Accum<T>(), null);
    public static (Func<int> init, Func<int, int, int> accum, Func<T, int> conv) Count<T>() => (Inits.Count(), Accumulators.Count(), null);
    public static (Func<double> init, Func<double, double, double>accum, Func<T, double> conv) Sum<T>() => (Inits.Sum(), Accumulators.Sum(), Num.CastDouble);
    public static (Func<Average> init, Func<Average, double, Average>accum, Func<T, double> conv) Average<T>() => (Inits.Average(), Accumulators.Average(), Num.CastDouble);
    public static (Func<double> init, Func<double, double, double>accum, Func<T, double> conv) Max<T>() => (Inits.Max(), Accumulators.Max(), Num.CastDouble);
    public static (Func<double> init, Func<double, double, double>accum, Func<T, double> conv) Min<T>() => (Inits.Min(), Accumulators.Min(), Num.CastDouble);
    public static (Func<object> init, Func<object, object, object>accum, Func<T, object> conv) First<T>() => (Inits.First(), Accumulators.First(), null);
    public static (Func<object> init, Func<object, object, object>accum, Func<T, object> conv) Last<T>() => (Inits.Last(), Accumulators.Last(), null);
  }
}
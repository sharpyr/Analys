// using System;
// using Analys.Pivot.Struct;
// using Analys.Types;
// using Typen.Numeral;
//
// namespace Analys.Pivot {
//   public static class PivotExt {
//     public static (dynamic initializer, dynamic accumulator, dynamic parser) ModeToPreset(this Pivoted mode) {
//       // (dynamic initializer, dynamic accumulator, dynamic parser) 
//       switch (mode) {
//         // case Pivoted.Accum: return Presets.Accum<dynamic>();
//         // case Pivoted.Merge: return Presets.Accum<dynamic>();
//         case Pivoted.Count: return Presets.Count<dynamic>();
//         case Pivoted.Sum: return Presets.Sum<dynamic>();
//         case Pivoted.Average: return Presets.Average<dynamic>();
//         // case Pivoted.StdDev: return Presets.StdDev<dynamic>();
//         case Pivoted.Max: return Presets.Max<dynamic>();
//         case Pivoted.Min: return Presets.Min<dynamic>();
//         default: throw new ArgumentOutOfRangeException(nameof(mode), mode, "Invalid PivotMode");
//       }
//     }
//   }
//
//   public static class Presets {
//     // public static (Func<T[]> initializer, Func<T[], T[], T[]> accumulator, Func<T[], T[], T[]>parser) Merge<T>() => (Initializers.Merge<T>(), Accumulators.Merge<T>(), null);
//     // public static (Func<T[]> initializer, Func<T[], T, T[]> accumulator, Func<T, T, T[]> parser) Accum<T>() => (Initializers.Accum<T>(), Accumulators.Accum<T>(), null);
//     public static (Func<int> initializer, Func<int, double, int> accumulator, Func<T, double> parser) Count<T>() => (Initializers.Count, Accumulators.Count, null);
//     public static (Func<double> initializer, Func<double, double, double>accumulator, Func<T, double> parser) Sum<T>() => (Initializers.Sum, Accumulators.Sum, Num.CastDouble);
//     public static (Func<Avg> initializer, Func<Avg, double, Avg>accumulator, Func<T, double> parser) Average<T>() => (Initializers.Average, Accumulators.Average, Num.CastDouble);
//     public static (Func<double> initializer, Func<double, double, double>accumulator, Func<T, double> parser) Max<T>() => (Initializers.Max, Accumulators.Max, Num.CastDouble);
//     public static (Func<double> initializer, Func<double, double, double>accumulator, Func<T, double> parser) Min<T>() => (Initializers.Min, Accumulators.Min, Num.CastDouble);
//   }
// }
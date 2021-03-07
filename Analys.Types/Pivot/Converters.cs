using System;
using Typen.Numeral;

namespace Analys.Pivot {
  public class Converters {
    public static Func<T[], T[], T[]> Merge<T>() => null;
    public static Func<T, T, T[]> Accum<T>() => null;
    public static Func<T, double> Count<T>() => Num.CastDouble;
    public static Func<T, double> Sum<T>() => Num.CastDouble;
    public static Func<T, double> Average<T>() => Num.CastDouble;
    public static Func<T, double> Max<T>() => Num.CastDouble;
    public static Func<T, double> Min<T>() => Num.CastDouble;
    public static Func<T, object> First<T>() => null;
    public static Func<T, object> Last<T>() => null;
  }
}
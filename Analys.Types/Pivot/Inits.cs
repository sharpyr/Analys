using System;
using Analys.Types;
using Analys.Utils;

namespace Analys.Pivot {
  public static class Inits {
    public static Func<T[]> Merge<T>() => Factory<T>.Vector;
    public static Func<T[]> Accum<T>() => Factory<T>.Vector;
    public static Func<int> Count() => () => 0;
    public static Func<double> Sum() => () => 0;
    public static Func<Average> Average() => Types.Average.Build;
    public static Func<double> Max() => () => double.NegativeInfinity;
    public static Func<double> Min() => () => double.PositiveInfinity;
    public static Func<object> First() => () => null;
    public static Func<object> Last() => () => null;
  }
}
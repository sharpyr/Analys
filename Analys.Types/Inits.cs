using System;

namespace Analys.Types {
  public static class Inits {
    public static Func<T[]> Merge<T>() => Factory<T>.Vector;
    public static Func<T[]> Accum<T>() => Factory<T>.Vector;
    public static Func<int> Count() => () => 0;
    public static Func<double> Incre() => () => 0;
    public static Func<double> Max() => () => double.NegativeInfinity;
    public static Func<double> Min() => () => double.PositiveInfinity;
    public static Func<object> First() => () => null;
    public static Func<object> Last() => () => null;
    public static Func<Average> Average() => Types.Average.Build;
  }
}
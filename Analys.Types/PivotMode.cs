using System;

namespace Analys.Types {
  public enum PivotMode {
    Merge,
    Accum,
    Incre,
    Count,
    Average,
    Max,
    Min,
    First,
    Last,
  }

  public static class InitFactory {
    public static Func<int> BuildNumber => () => 0;
  }

  public static class InitFactory<T> {
    public static Func<T[]> BuildVector => () => new T[] { };
  }

  public static class ModeToInit {
    public static Func<T[]> Merge<T>() => InitFactory<T>.BuildVector;
    public static Func<T[]> Accum<T>() => InitFactory<T>.BuildVector;
    public static Func<double> Incre() => () => 0;
    public static Func<int> Count() => () => 0;
    public static Func<double> Max() => () => double.NegativeInfinity;
    public static Func<double> Min() => () => double.PositiveInfinity;
    public static Func<object> First => () => null;
    public static Func<object> Last => () => null;
  }
}
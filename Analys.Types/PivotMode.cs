using System;
using System.Linq;
using Veho.Vector;

namespace Analys.Types {
  public enum PivotMode {
    Merge,
    Accum,
    Count,
    Incre,
    Max,
    Min,
    First,
    Last,
    Average,
  }

  public static class Factory<T> {
    public static Func<T[]> Vector => () => new T[] { };
  }

  public struct Average {
    public double Sum { get; set; }
    public int Count { get; set; }
    public double Value => Count == 0 ? 0 : Sum / Count;

    public Average Take(double num) {
      this.Sum += num;
      this.Count += 1;
      return this;
    }
    public static Average Build() => new Average {Sum = 0, Count = 0};
  }

  public static class PivotPreset {
    public static (Func<T[]> init, Func<T[], T[], T[]> accum) Merge<T>() => (ModeToInit.Merge<T>(), ModeToAccumulator.Merge<T>());
    public static (Func<T[]> init, Func<T[], T, T[]> accum) Accum<T>() => (ModeToInit.Accum<T>(), ModeToAccumulator.Accum<T>());
    public static (Func<int> init, Func<int, int, int> accum) Count() => (ModeToInit.Count(), ModeToAccumulator.Count());
    public static (Func<double> init, Func<double, double, double>accum) Incre() => (ModeToInit.Incre(), ModeToAccumulator.Incre());
    public static (Func<double> init, Func<double, double, double>accum) Max() => (ModeToInit.Max(), ModeToAccumulator.Max());
    public static (Func<double> init, Func<double, double, double>accum) Min() => (ModeToInit.Min(), ModeToAccumulator.Min());
    public static (Func<object> init, Func<object, object, object>accum) First() => (ModeToInit.First(), ModeToAccumulator.First());
    public static (Func<object> init, Func<object, object, object>accum) Last() => (ModeToInit.Last(), ModeToAccumulator.Last());
    public static (Func<Average> init, Func<Average, double, Average>accum) Average() => (ModeToInit.Average(), ModeToAccumulator.Average());
  }

  public static class ModeToInit {
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

  public static class ModeToAccumulator {
    public static Func<T[], T[], T[]> Merge<T>() => (target, value) => value == null ? target : target.Concat(value).ToArray();
    public static Func<T[], T, T[]> Accum<T>() => (target, value) => value == null ? target : target.Push(value);
    public static Func<int, int, int> Count() => (target, value) => double.IsNaN(value) ? target : target + 1;
    public static Func<double, double, double> Incre() => (target, value) => double.IsNaN(value) ? target : target + value;
    public static Func<double, double, double> Max() => (target, value) => double.IsNaN(value) ? target : Math.Max(target, value);
    public static Func<double, double, double> Min() => (target, value) => double.IsNaN(value) ? target : Math.Min(target, value);
    public static Func<object, object, object> First() => (target, value) => target ?? value;
    public static Func<object, object, object> Last() => (target, value) => value ?? target;
    public static Func<Average, double, Average> Average() => (target, value) => double.IsNaN(value) ? target : target.Take(value);
  }
}
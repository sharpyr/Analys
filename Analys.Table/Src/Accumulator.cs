using System.Collections.Generic;
using Generic.Math;

namespace Analys.Table {
  public enum Accumulated {
    Merge,
    Accum,
    Incre,
    Count,
    Average,
    Max,
    Min,
    First,
    Last
  }

  public static class Accumulator<T> {
    public static List<T> Merge(List<T> target, List<T> value) {
      if (value == null) return target;
      target.AddRange(value);
      return target;
    }
    public static List<T> Accum(List<T> target, T value) {
      target.Add(value);
      return target;
    }
    public static T Incre(T target, T value) => GenericMath<T>.Add(target, value);
    public static int Count(int target, T value) => ++target;
    public static (T sum, int count) Average((T sum, int count) target, T value) =>
      (GenericMath<T>.Add(target.sum, value), ++target.count);
    public static T Max(T target, T value) => GenericMath<T>.GreaterThanOrEqual(target, value) ? target : value;
    public static T Min(T target, T value) => GenericMath<T>.LessThanOrEqual(target, value) ? target : value;
    public static object First(object target, object value) => target ?? value;
    public static object Last(object target, object value) => value ?? target;
  }

  public static class Accumulator {
    public static object Incre(object target, object value) => GenericMath.Add(target, value);
    public static int Count(int target, object value) => ++target;
    public static (object sum, int count) Average((object sum, int count) target, object value) => (GenericMath.Add(target.sum, value), ++target.count);
    public static object Max(object target, object value) => GenericMath.GreaterThanOrEqual(target, value) ? target : value;
    public static object Min(object target, object value) => GenericMath.LessThanOrEqual(target, value) ? target : value;
    public static object First(object target, object value) => target ?? value;
    public static object Last(object target, object value) => value ?? target;
  }
}
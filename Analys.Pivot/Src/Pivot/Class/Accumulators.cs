using System.Linq;
using Veho.Vector;

namespace Analys.Pivot.Class {
  public static class Accumulators {
    public static T[] Merge<T>(T[] target, T[] value) => value == null ? target : target.Concat(value).ToArray();
    public static T[] Accum<T>(T[] target, T value) => value == null ? target : target.Push(value);
  }
}
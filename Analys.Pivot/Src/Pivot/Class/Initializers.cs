using System;
using Analys.Utils;

namespace Analys.Pivot.Class {
  public static class Initializers {
    public static Func<T[]> Merge<T>() => Factory<T>.Vector;
    public static Func<T[]> Accum<T>() => Factory<T>.Vector;
  }
}
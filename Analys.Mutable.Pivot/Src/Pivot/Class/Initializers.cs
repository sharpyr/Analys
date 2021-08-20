using System;
using System.Collections.Generic;
using Analys.Utils;

namespace Analys.Mutable.Pivot.Class {
  public static class Initializers {
    public static Func<List<T>> Merge<T>() => Factory<T>.Sequence;
    public static Func<List<T>> Accum<T>() => Factory<T>.Sequence;
  }
}
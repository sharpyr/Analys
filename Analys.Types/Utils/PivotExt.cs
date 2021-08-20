using System;
using System.Collections.Generic;

namespace Analys.Utils {
  public static class Factory<T> {
    public static Func<T[]> Vector => () => new T[] { };
    public static Func<List<T>> Sequence => () => new List<T> { };
  }
}
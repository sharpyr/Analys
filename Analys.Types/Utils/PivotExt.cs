﻿using System;

namespace Analys.Utils {
  public static class Factory<T> {
    public static Func<T[]> Vector => () => new T[] { };
  }
}
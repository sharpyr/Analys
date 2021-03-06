﻿using System;
using System.Linq;
using Analys.Types;
using Veho.Vector;
using static System.Double;

namespace Analys.Pivot {
  public static class Accumulators {
    public static Func<T[], T[], T[]> Merge<T>() => (target, value) => value == null ? target : target.Concat(value).ToArray();
    public static Func<T[], T, T[]> Accum<T>() => (target, value) => value == null ? target : target.Push(value);
    public static Func<int, double, int> Count() => (target, value) => IsNaN(value) ? target : target + 1;
    public static Func<double, double, double> Sum() => (target, value) => IsNaN(value) ? target : target + value;
    public static Func<double, double, double> Max() => (target, value) => IsNaN(value) ? target : Math.Max(target, value);
    public static Func<double, double, double> Min() => (target, value) => IsNaN(value) ? target : Math.Min(target, value);
    public static Func<object, object, object> First() => (target, value) => target ?? value;
    public static Func<object, object, object> Last() => (target, value) => value ?? target;
    public static Func<Average, double, Average> Average() => (target, value) => IsNaN(value) ? target : target.Take(value);
  }
}
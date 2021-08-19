using System;
using Analys.Types;
using static System.Double;

namespace Analys.Pivot.Struct {
  public static class Accumulators {
    public static int Count(int target, double value) => IsNaN(value) ? target : target + 1;
    public static double Sum(double target, double value) => IsNaN(value) ? target : target + value;
    public static Avg Average(Avg target, double value) => IsNaN(value) ? target : target.Record(value);
    public static double Max(double target, double value) => IsNaN(value) ? target : Math.Max(target, value);
    public static double Min(double target, double value) => IsNaN(value) ? target : Math.Min(target, value);
  }
}
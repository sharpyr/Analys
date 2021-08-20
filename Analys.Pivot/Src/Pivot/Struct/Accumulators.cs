using System;
using Analys.Types;
using Analys.Types.Sample;
using static System.Double;

namespace Analys.Pivot.Struct {
  public static class Accumulators {
    public static int Count(int target, double value) => IsNaN(value) ? target : target + 1;
    public static double Sum(double target, double value) => IsNaN(value) ? target : target + value;
    public static Avg Average(Avg target, double value) => IsNaN(value) ? target : (Avg)target.Record(value);
    public static StDev StDev(StDev target, double value) => IsNaN(value) ? target : (StDev)target.Record(value);
    public static Var Var(Var target, double value) => IsNaN(value) ? target : (Var)target.Record(value);
    public static Skew Skew(Skew target, double value) => IsNaN(value) ? target : (Skew)target.Record(value);
    public static Kurt Kurt(Kurt target, double value) => IsNaN(value) ? target : (Kurt)target.Record(value);
    public static double Max(double target, double value) => IsNaN(value) ? target : Math.Max(target, value);
    public static double Min(double target, double value) => IsNaN(value) ? target : Math.Min(target, value);
  }
}
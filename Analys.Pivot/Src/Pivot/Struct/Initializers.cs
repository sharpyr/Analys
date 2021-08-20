using Analys.Types;

namespace Analys.Pivot.Struct {
  public static class Initializers {
    public static int Count() => 0;
    public static double Sum() => 0;
    // public static Avg Average() => Avg.Build();
    // public static StDev StandardDeviation() => StDev.Build();
    // public static Var Variation() => Var.Build();
    // public static Skew Skewness() => Skew.Build();
    // public static Kurt Kurtosis() => Kurt.Build();
    public static double Max() => double.NegativeInfinity;
    public static double Min() => double.PositiveInfinity;
  }
}
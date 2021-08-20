using static System.Math;

namespace Analys.Types {
  public static class MathExt {
    public static double P2(this double n) { return Pow(n, 2); }
    public static double P3(this double n) { return Pow(n, 3); }
    public static double P4(this double n) { return Pow(n, 4); }
  }
}
using Analys.Stat.Gadget.Utils;
using static System.Math;

namespace Analys.Stat.Gadget.Population {
  public struct Skew : IStat {
    public double SumCu;
    public double SumSq;
    public double Sum;
    public int N;
    private double Mean => Sum / N;
    public double StDev => Sqrt(SumSq / N - Mean.P2());
    public double Value => (SumCu / N - 3 * Mean * StDev.P2() - Mean.P3()) / StDev.P3();
    public IStat Record(double num) {
      Sum += num;
      SumSq += num.P2();
      SumCu += num.P3();
      N++;
      return this;
    }
    public static IStat Build() { return new Skew { SumCu = 0, SumSq = 0, Sum = 0, N = 0 }; }
  }
}
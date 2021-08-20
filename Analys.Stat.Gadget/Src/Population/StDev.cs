using Analys.Stat.Utils;
using static System.Math;

namespace Analys.Stat.Population {
  public struct StDev : IStat {
    public double SumSq;
    public double Sum;
    public int N;
    public double Value => Sqrt(SumSq / N - (Sum / N).P2());
    public IStat Record(double num) {
      Sum += num;
      SumSq += num.P2();
      N++;
      return this;
    }
    public static IStat Build() { return new StDev { SumSq = 0, Sum = 0, N = 0 }; }
  }
}
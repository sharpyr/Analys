using Analys.Stat.Utils;

namespace Analys.Stat.Population {
  public struct Var : IStat {
    public double SumSq;
    public double Sum;
    public int N;
    public double Value => SumSq / N - (Sum / N).P2();
    public IStat Record(double num) {
      Sum += num;
      SumSq += num.P2();
      N++;
      return this;
    }
    public static IStat Build() { return new Var { SumSq = 0, Sum = 0, N = 0 }; }
  }
}
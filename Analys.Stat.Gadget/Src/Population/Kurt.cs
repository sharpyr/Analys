using Analys.Stat.Gadget.Utils;

namespace Analys.Stat.Gadget.Population {
  public struct Kurt : IStat {
    public double SumQu;
    public double SumCu;
    public double SumSq;
    public double Sum;
    public int N;
    private double Mean => Sum / N;
    public double Var => SumSq / N - Mean.P2();
    public double Value => (SumQu / N - 4 * SumCu / N * Mean + 6 * SumSq / N * Mean.P2() - 3 * Mean.P4()) / Var.P2();
    public IStat Record(double num) {
      Sum += num;
      SumSq += num.P2();
      SumCu += num.P3();
      SumQu += num.P4();
      N++;
      return this;
    }
    public static IStat Build() { return new Kurt { SumQu = 0, SumCu = 0, SumSq = 0, Sum = 0, N = 0 }; }
  }
}
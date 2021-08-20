using System;
using Analys.Stat.Gadget.Population;
using Analys.Types;

namespace Analys.Stat.Gadget {
  public static class GadgetFactory {
    public static Func<IStat> Build(Pivoted pivoted) {
      switch (pivoted) {
        case Pivoted.Count: return GadgetFactory.Avg;
        case Pivoted.Sum: return GadgetFactory.Avg;
        case Pivoted.Average: return GadgetFactory.Avg;
        case Pivoted.Var: return GadgetFactory.Var;
        case Pivoted.StDev: return GadgetFactory.StDev;
        case Pivoted.Skew: return GadgetFactory.Skew;
        case Pivoted.Kurt: return GadgetFactory.Kurt;
        default: throw new ArgumentOutOfRangeException(nameof(pivoted), pivoted, null);
      }
    }
    public static IStat Avg() => new Avg { Sum = 0, Count = 0 };
    public static IStat Var() => new Var { SumSq = 0, Sum = 0, N = 0 };
    public static IStat StDev() => new StDev { SumSq = 0, Sum = 0, N = 0 };
    public static IStat Skew() => new Skew { SumCu = 0, SumSq = 0, Sum = 0, N = 0 };
    public static IStat Kurt() => new Kurt { SumQu = 0, SumCu = 0, SumSq = 0, Sum = 0, N = 0 };
  }
}
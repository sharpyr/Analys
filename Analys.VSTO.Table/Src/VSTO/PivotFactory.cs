using System;
using Analys.Stat;
using Analys.Types;
using Acc = Analys.Pivot.Struct.Accumulators;
using Init = Analys.Pivot.Struct.Initializers;

namespace Analys.VSTO {
  public static class PivotFactory {
    public static Pivot<TAccum, TSample> Build<TAccum, TSample>(
      Func<TAccum> initializer,
      Func<TAccum, TSample, TAccum> accumulator
    ) => new Pivot<TAccum, TSample> {
                                      Accumulator = accumulator,
                                      Init = initializer,
                                      Side = new string[] { },
                                      Head = new string[] { },
                                      Rows = new TAccum[][] { },
                                    };

    public static Pivot<IStat, double> Build(
      Pivoted pivoted
    ) => new Pivot<IStat, double> {
                                    Accumulator = StatExt.Record,
                                    Init = GadgetFactory.Build(pivoted),
                                    Side = new string[] { },
                                    Head = new string[] { },
                                    Rows = new IStat[][] { },
                                  };

    public static Pivot<int, double> Count() => Build<int, double>(Init.Count, Acc.Count);
    public static Pivot<double, double> Sum() => Build<double, double>(Init.Sum, Acc.Sum);
  }
}
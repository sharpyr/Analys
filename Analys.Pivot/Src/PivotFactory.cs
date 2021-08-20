using System;
using Analys.Stat;
using Analys.Types;
using Acc = Analys.Pivot.Struct.Accumulators;
using Init = Analys.Pivot.Struct.Initializers;
using FieldIndexes = System.ValueTuple<int, int, int>;

namespace Analys {
  public static class PivotFactory {
    public static Pivot<TAccum, TSample> Build<TAccum, TSample>(
      FieldIndexes indexes,
      Func<TAccum> initializer,
      Func<TAccum, TSample, TAccum> accumulator
    ) =>
      new Pivot<TAccum, TSample> {
        Indexes = indexes,
        Accumulator = accumulator,
        Init = initializer,
        Side = new string[] { },
        Head = new string[] { },
        Rows = new TAccum[][] { },
      };
    
    public static Pivot<IStat, double> Build(
      FieldIndexes indexes,
      Pivoted pivoted
    ) =>
      new Pivot<IStat, double> {
        Indexes = indexes,
        Accumulator = StatExt.Record,
        Init = GadgetFactory.Build(pivoted),
        Side = new string[] { },
        Head = new string[] { },
        Rows = new IStat[][] { },
      };

    public static Pivot<int, double> Count(FieldIndexes indexes) => PivotFactory.Build<int, double>(indexes, Init.Count, Acc.Count);
    public static Pivot<double, double> Sum(FieldIndexes indexes) => PivotFactory.Build<double, double>(indexes, Init.Sum, Acc.Sum);
  }
}
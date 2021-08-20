using Analys.Types;
using Analys.Types.Sample;
using Acc = Analys.Pivot.Struct.Accumulators;
using Init = Analys.Pivot.Struct.Initializers;
using FieldIndexes = System.ValueTuple<int, int, int>;
using S = Analys.Types.Sample;

namespace Analys {
  public static class PivotFactory {
    public static Pivot<double, int> Count(FieldIndexes indexes) => Pivot<double, int>.Build(indexes, Init.Count, Acc.Count);
    public static Pivot<double, double> Sum(FieldIndexes indexes) => Pivot<double, double>.Build(indexes, Init.Sum, Acc.Sum);
    public static Pivot<double, IStat> Average(FieldIndexes indexes) => Pivot<double, Avg>.Build(indexes, Avg.Build);
    public static Pivot<double, IStat> StDev(FieldIndexes indexes) => Pivot<double, StDev>.Build(indexes, S::StDev.Build);
    public static Pivot<double, IStat> Var(FieldIndexes indexes) => Pivot<double, Var>.Build(indexes, S::Var.Build);
    public static Pivot<double, IStat> Skew(FieldIndexes indexes) => Pivot<double, Skew>.Build(indexes, S::Skew.Build);
    public static Pivot<double, IStat> Kurt(FieldIndexes indexes) => Pivot<double, Kurt>.Build(indexes, S::Kurt.Build);
    // public static Pivot<T, int> StdDev<T>(int side, int head, int field) => Pivot<T, int>.Build(side, head, field, Initializers.Count, Accumulators.Count);
  }
}
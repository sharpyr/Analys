using Analys.Types;
using Acc = Analys.Pivot.Struct.Accumulators;
using Init = Analys.Pivot.Struct.Initializers;
using FieldIndexes = System.ValueTuple<int, int, int>;

namespace Analys {
  public static class PivotFactory {
    public static Pivot<double, int> Count(FieldIndexes indexes) => Pivot<double, int>.Build(indexes, Init.Count, Acc.Count);
    public static Pivot<double, double> Sum(FieldIndexes indexes) => Pivot<double, double>.Build(indexes, Init.Sum, Acc.Sum);
    public static Pivot<double, Avg> Average(FieldIndexes indexes) => Pivot<double, Avg>.Build(indexes, Init.Average, Acc.Average);
    // public static Pivot<T, int> StdDev<T>(int side, int head, int field) => Pivot<T, int>.Build(side, head, field, Initializers.Count, Accumulators.Count);
  }
}
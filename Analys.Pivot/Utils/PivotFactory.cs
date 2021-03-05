using System;

namespace Analys.Utils {
  public static class PivotFactory {
    public static Pivot<T, TP> CreatePivot<T, TP>(this (Func<TP> init, Func<TP, T, TP> accum) pivotPreset, int side,
      int head, int field) =>
      Pivot<T, TP>.Build(side, head, field, pivotPreset.init, pivotPreset.accum);
  }
}
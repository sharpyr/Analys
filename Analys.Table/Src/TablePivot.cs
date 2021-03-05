using System;
using Analys.Pivot;
using Analys.Types;

namespace Analys.Table {
  public static class TablePivot {
    public static (string[] side, string[] head, TP[,] rows) ToCrostab<T, TP>(
      this Table<object> table,
      (Func<TP> init, Func<TP, T, TP> accum) pivotPreset,
      string side,
      string head,
      string field
    ) {
      var sideIndex = table.CoIn(side);
      var headIndex = table.CoIn(head);
      var fieldIndex = table.CoIn(field);
      var pivot = pivotPreset.CreatePivot(sideIndex, headIndex, fieldIndex);
      pivot.Record(table.Rows);
      return pivot.ToTuple();
    }

    // public static (string[] side, string[] head, TP[,] rows) ToCrostab<T, TP>(
    //   this Table table,
    //   string side,
    //   string head,
    //   string field,
    //   PivotMode mode
    // ) {
    //   var sideIndex = table.CoIn(side);
    //   var headIndex = table.CoIn(head);
    //   var fieldIndex = table.CoIn(field);
    //   var pivot = Pivot<T, TP>.Build(sideIndex, headIndex, fieldIndex, mode);
    //   pivot.Record(table.Rows);
    //   return pivot.ToTuple();
    // }
  }
}
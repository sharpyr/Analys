using System;
using Analys.Types;

namespace Analys {
  public static class TableToCrostab {
    public static Crostab<dynamic> ToCrostab(
      this Table<dynamic> table,
      string side,
      string head,
      string field,
      PivotMode mode
    ) => Pivot<dynamic, dynamic>
      .Build(table.CoIn(side), table.CoIn(head), table.CoIn(field), mode)
      .Record(table.Rows)
      .ToCrostab();

    public static Crostab<TO> ToCrostab<TO>(
      this Table<dynamic> table,
      string side,
      string head,
      string field,
      PivotMode mode
    ) => Pivot<dynamic, dynamic>
      .Build(table.CoIn(side), table.CoIn(head), table.CoIn(field), mode)
      .Record(table.Rows)
      .ToCrostab<dynamic, TO>();

    public static Crostab<TO> ToCrostab<TO>(
      this Table<dynamic> table,
      string side,
      string head,
      string field,
      PivotMode mode,
      Func<dynamic, TO> conv
    ) => Pivot<dynamic, dynamic>
      .Build(table.CoIn(side), table.CoIn(head), table.CoIn(field), mode)
      .Record(table.Rows)
      .ToCrostab(conv);
  }
}
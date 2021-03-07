using System;
using Analys.Types;

namespace Analys {
  public static class TableToCrostab {
    public static Crostab<TO> ToCrostab<TO>(
      this Table<dynamic> table,
      string side,
      string head,
      string field,
      Pivoted mode,
      Func<dynamic, TO> formula = null,
      Func<object, dynamic> parser = null
    ) => Pivot<dynamic, dynamic, dynamic>
      .Build(table.CoIn(side), table.CoIn(head), table.CoIn(field), mode)
      .Record(table.Rows, parser)
      .ToCrostab(formula);
  }
}
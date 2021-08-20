using System;
using Analys.Types;
using Typen;

namespace Analys {
  public static class TableToCrostab {

    public static Crostab<double> Crostab(
      this Table<object> table,
      (string side, string head, string field) fields,
      Pivoted mode,
      Func<object, double> parser = null
    ) {
      if (parser == null) parser = Numeral.CastDouble;
      var indexes = table.GetIndexes(fields);
      switch (mode) {
        case Pivoted.Count: return PivotFactory.Count(indexes).Record(table.Rows, parser).ToCrostab(x => (double)x);
        case Pivoted.Sum: return PivotFactory.Sum(indexes).Record(table.Rows, parser).ToCrostab();
        default: return PivotFactory.Build(indexes, mode).Record(table.Rows, parser).ToCrostab(x => x.Value);
      }
    }
  }
}
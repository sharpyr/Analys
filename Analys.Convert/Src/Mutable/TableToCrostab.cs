using System;
using Analys.Types;
using Typen;
using Mu = Analys.Mutable;

namespace Analys.Mutable {
  public static class TableToCrostab {
    public static Mu::Crostab<double> Crostab(
      this Mu::Table<object> table,
      (string side, string head, string field) fields,
      Pivoted mode,
      Func<object, double> parser = null
    ) {
      if (parser == null) parser = Numeral.CastDouble;
      var indexes = table.GetIndexes(fields);
      switch (mode) {
        case Pivoted.Count: return Mu::PivotFactory.Count(indexes).Record(table.Rows, parser).ToCrostab(x => (double)x);
        case Pivoted.Sum: return Mu::PivotFactory.Sum(indexes).Record(table.Rows, parser).ToCrostab();
        default: return Mu::PivotFactory.Build(indexes, mode).Record(table.Rows, parser).ToCrostab(x => x.Value);
      }
    }
  }
}
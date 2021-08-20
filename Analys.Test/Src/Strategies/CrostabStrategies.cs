using System;
using System.Collections.Generic;
using System.Linq;
using Analys.Mutable;
using Analys.Test.Assets;
using Analys.Types;
using NUnit.Framework;
using Spare;
using Texting.Enums;
using Typen;
using Veho;
using Veho.Enumerable;
using Veho.Mutable.Matrix;
using Veho.Types;
using static System.Double;
using static Palett.Presets;
using Mu = Analys.Mutable;

namespace Analys.Test.Strategies {
  [TestFixture]
  public class CrostabStrategies {
    [Test]
    public void CrostabBenchmarkSimple() {
      var (elapsed, result) = Valjoux.Strategies.Run(
        (int)2E+4,
        Seq.From<(string, Func<Pivoted, Crostab<double>>)>(
          ("DutyRoster", mode => TableCollection.DutyRosterTable.Crostab(("name", "day", "served"), mode)),
          ("Borat", mode => TableCollection.BoratTable.Crostab(("name", "day", "kpi"), mode))
        ),
        Enum<Pivoted>.Values.Map((Pivoted pivoted) => (pivoted.Label(), pivoted)).ToList()
      );
      elapsed.Deco(orient: Operated.Rowwise, presets: (Subtle, Fresh)).Says("Elapsed", Strings.LF);
      result.Deco().Says("Result", Strings.LF);
      foreach (var name in Enum<Pivoted>.Names) {
        result[name, "Borat"].Map(x => x.ToString("F2")).Deco(presets: (Subtle, Fresh)).Says("Borat : " + name, Strings.LF);
      }
    }
    [Test]
    public void MutableCrostabBenchmarkSimple() {
      var fields = ("name", "day", "sold");
      var (elapsed, result) = Valjoux.Strategies.Run(
        (int)2E+4,
        Seq.From<(string, Func<Pivoted, Mu::Crostab<double>>)>(
          ("DutyRoster", mode => MutableTableCollection.DutyRosterTable.Crostab(("name", "day", "served"), mode)),
          ("Borat", mode => MutableTableCollection.BoratTable.Crostab(("name", "day", "kpi"), mode))
        ),
        Enum<Pivoted>.Values.Map((Pivoted pivoted) => (pivoted.Label(), pivoted)).ToList()
      );
      elapsed.Deco(orient: Operated.Rowwise, presets: (Subtle, Fresh)).Says("Elapsed", Strings.LF);
      result.Deco().Says("Result", Strings.LF);
      foreach (var name in Enum<Pivoted>.Names) {
        result[name, "Borat"].Map(x => x.ToString("F2")).ToCrostab().Deco(presets: (Subtle, Fresh)).Says("Borat : " + name, Strings.LF);
      }
    }
  }
}
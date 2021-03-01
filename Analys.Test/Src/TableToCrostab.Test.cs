using System;
using System.Linq;
using Analys.Crostab;
using Analys.Table;
using Analys.Types;
using NUnit.Framework;
using Spare.Deco;
using Spare.Logger;

namespace Analys.Test {
  public static class TableToCrostabExt {
    public static Crostab<T> Crostab<T>(
      this Table<T> table,
      string head,
      string side,
      string field,
      PivotMode mode
    ) {
      var columnX = table.Column(side);
      var columnY = table.Column(head);
      var columnZ = table.Column(field);
      var elementsX = columnX.AsEnumerable().Distinct().ToArray();
      var elementsY = columnY.AsEnumerable().Distinct().ToArray();
      var matrix = new T[elementsX.Length, elementsY.Length];
      var triZipper = (Func<string, string, T, T>) ((x, y, z) => default);
      // return triZipper.Zipper(columnX,columnY,columnY)
      return new Crostab<T>();
    }
  }

  [TestFixture]
  public class TableToCrostabTest {
    [Test]
    public void SimpleTest() {
      var table = Table<object>.Build(
        new[] {"day", "name", "served", "sold", "adt"},
        new object[,] {
          {1, "Joyce", 70, 7, ""},
          {1, "Joyce", 66, 15, ""},
          {2, "Joyce", 86, 10, ""},
          {2, "Joyce", double.NaN, double.NaN, ""},
          {3, "Joyce", 96, 2, ""},
          {1, "Lance", 98, 15, ""},
          {1, "Lance", 66, 15, ""},
          {2, "Lance", 85, 12, ""},
          {2, "Lance", 63, 12, ""},
          {3, "Lance", double.NaN, double.NaN, ""},
          {1, "Naomi", 90, 14, ""},
          {1, "Naomi", 66, 9, ""},
          {2, "Naomi", double.NaN, double.NaN, ""},
          {2, "Naomi", 93, 16, ""},
          {3, "Naomi", 78, 8, ""},
        }
      );
      var (side, head, rows) = table.ToCrostab(PivotPreset.Incre(), "name", "day", "sold");
      var crostab = Crostab<double>.Build(side, head, rows);
      crostab.Side.Deco().Logger();
      crostab.Head.Deco().Logger();
      crostab.Rows.Deco().Logger();
    }
  }
}
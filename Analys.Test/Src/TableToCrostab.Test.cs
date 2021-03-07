using System;
using System.Linq;
using Analys.Types;

namespace Analys.Test {
  public static class TableToCrostabExt {
    public static Crostab<T> Crostab<T>(
      this Table<T> table,
      string head,
      string side,
      string field,
      Pivoted mode
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
}
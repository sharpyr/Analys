// using System;
// using System.Linq;
// using Analys.Types;
// using NUnit.Framework;
// using Spare;
// using Veho;
//
// namespace Analys.Test {
//   [TestFixture]
//   public class ToCrostabTests {
//     [Test]
//     public void ToCrostabTestAlpha() {
//       var bistroDutyRoster = Table.Build(
//         Vec.From("day", "name", "served", "sold", "adt"),
//         Mat.From(
//           Vec.From<object>(1, "Joyce", 70, 7, ""),
//           Vec.From<object>(1, "Joyce", 66, 15, ""),
//           Vec.From<object>(2, "Joyce", 86, 10, ""),
//           Vec.From<object>(2, "Joyce", double.NaN, double.NaN, ""),
//           Vec.From<object>(3, "Joyce", 96, 2, ""),
//           Vec.From<object>(1, "Lance", 98, 15, ""),
//           Vec.From<object>(1, "Lance", 66, 15, ""),
//           Vec.From<object>(2, "Lance", 85, 12, ""),
//           Vec.From<object>(2, "Lance", 63, 12, ""),
//           Vec.From<object>(3, "Lance", double.NaN, double.NaN, ""),
//           Vec.From<object>(1, "Naomi", 90, 14, ""),
//           Vec.From<object>(1, "Naomi", 66, 9, ""),
//           Vec.From<object>(2, "Naomi", double.NaN, double.NaN, ""),
//           Vec.From<object>(2, "Naomi", 93, 16, ""),
//           Vec.From<object>(3, "Naomi", 78, 8, "")
//         )
//       );
//       bistroDutyRoster.Deco().Logger();
//       var crostab = bistroDutyRoster.Crostab(
//         side: "name",
//         head: "day",
//         field: "served",
//         mode: Pivoted.Sum,
//         formula: Typen.Numeral.Num.CastDouble
//       );
//       crostab.Deco().Logger();
//     }
//   }
//
//   public static class TableToCrostabExt {
//     public static Crostab<T> Crostab<T>(
//       this Table<T> table,
//       string head,
//       string side,
//       string field,
//       Pivoted mode
//     ) {
//       var columnX = table.Column(side);
//       var columnY = table.Column(head);
//       var columnZ = table.Column(field);
//       var elementsX = columnX.AsEnumerable().Distinct().ToArray();
//       var elementsY = columnY.AsEnumerable().Distinct().ToArray();
//       var matrix = new T[elementsX.Length, elementsY.Length];
//       var triZipper = (Func<string, string, T, T>)((x, y, z) => default);
//       // return triZipper.Zipper(columnX,columnY,columnY)
//       return new Crostab<T>();
//     }
//   }
// }
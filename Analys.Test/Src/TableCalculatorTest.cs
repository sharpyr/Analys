// using Aryth;
// using NUnit.Framework;
// using Spare;
// using Veho;
// using static System.Double;
// using Math = System.Math;
//
// namespace Analys.Test {
//   [TestFixture]
//   public class TableCalculatorTest {
//     [Test]
//     public void TableCalculatorTestAlpha() {
//       var table = Table<dynamic>.Build(
//         new[] { "day", "name", "served", "sold", "adt" },
//         new dynamic[,] {
//                          { 1, "Joyce", 70D, 7D, "" },
//                          { 1, "Joyce", 66D, 15D, "" },
//                          { 2, "Joyce", 86D, 10D, "" },
//                          { 2, "Joyce", NaN, NaN, "" },
//                          { 3, "Joyce", 96D, 2D, "" },
//                          { 1, "Lance", 98D, 15D, "" },
//                          { 1, "Lance", 66D, 15D, "" },
//                          { 2, "Lance", 85D, 12D, "" },
//                          { 2, "Lance", 63D, 12D, "" },
//                          { 3, "Lance", NaN, NaN, "" },
//                          { 1, "Naomi", 90D, 14D, "" },
//                          { 1, "Naomi", 66D, 9D, "" },
//                          { 2, "Naomi", NaN, NaN, "" },
//                          { 2, "Naomi", 93D, 16D, "" },
//                          { 3, "Naomi", 78D, 8D, "" },
//                        }
//       );
//       var columnTable = table.ToColumnTable();
//       columnTable["served"].Deco().Says("served");
//       columnTable["sold"].Deco().Says("sold");
//       var algebraCalculator = AlgebraCalculator.Build(columnTable, typeof(LinearSpace<dynamic>), typeof(Math));
//     }
//   }
// }
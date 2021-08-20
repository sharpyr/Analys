using Veho;
using static System.Double;

namespace Analys.Test.Assets {
  public static class TableCollection {
    public static Table<object> BoratTable = Table<object>.Build(
      Vec.From("day", "name", "kpi", "qtt", "adt"),
      Mat.From(
        //
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        Vec.From<object>(1, "Glen", 1, 0, ""),
        //
        Vec.From<object>(2, "Fara", 1, 0, ""),
        Vec.From<object>(2, "Fara", 2, 0, ""),
        Vec.From<object>(2, "Fara", 3, 0, ""),
        Vec.From<object>(2, "Fara", 4, 0, ""),
        Vec.From<object>(2, "Fara", 5, 0, ""),
        Vec.From<object>(2, "Fara", 6, 0, ""),
        Vec.From<object>(2, "Fara", 7, 0, ""),
        Vec.From<object>(2, "Fara", 8, 0, ""),
        Vec.From<object>(2, "Fara", 9, 0, ""),
        Vec.From<object>(2, "Fara", 10, 0, ""),
        //
        Vec.From<object>(1, "Skye", 1, 0, ""),
        Vec.From<object>(1, "Skye", 9, 0, ""),
        Vec.From<object>(1, "Skye", 36, 0, ""),
        Vec.From<object>(1, "Skye", 84, 0, ""),
        Vec.From<object>(1, "Skye", 126, 0, ""),
        Vec.From<object>(1, "Skye", 126, 0, ""),
        Vec.From<object>(1, "Skye", 84, 0, ""),
        Vec.From<object>(1, "Skye", 36, 0, ""),
        Vec.From<object>(1, "Skye", 9, 0, ""),
        Vec.From<object>(1, "Skye", 1, 0, ""),
        //
        Vec.From<object>(2, "Kemp", 3, 0, ""),
        Vec.From<object>(2, "Kemp", 3, 0, ""),
        Vec.From<object>(2, "Kemp", 4, 0, ""),
        Vec.From<object>(2, "Kemp", 4, 0, ""),
        Vec.From<object>(2, "Kemp", 8, 0, ""),
        Vec.From<object>(2, "Kemp", 8, 0, ""),
        Vec.From<object>(2, "Kemp", 10, 0, ""),
        Vec.From<object>(2, "Kemp", 10, 0, ""),
        Vec.From<object>(2, "Kemp", 100, 0, ""),
        Vec.From<object>(2, "Kemp", 1000, 0, "")
      )
    );
    public static Table<object> DutyRosterTable = Table.Build(
      new[] { "day", "name", "served", "sold", "adt" },
      new object[,] {
        { 1, "Joyce", 70, 7, "" },
        { 1, "Joyce", 66, 15, "" },
        { 2, "Joyce", 86, 10, "" },
        { 2, "Joyce", NaN, NaN, "" },
        { 3, "Joyce", 96, 2, "" },
        { 1, "Lance", 98, 15, "" },
        { 1, "Lance", 66, 15, "" },
        { 2, "Lance", 85, 12, "" },
        { 2, "Lance", 63, 12, "" },
        { 3, "Lance", NaN, NaN, "" },
        { 1, "Naomi", 90, 14, "" },
        { 1, "Naomi", 66, 9, "" },
        { 2, "Naomi", NaN, NaN, "" },
        { 2, "Naomi", 93, 16, "" },
        { 3, "Naomi", 78, 8, "" },
      }
    );
  }
}
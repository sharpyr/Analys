using Veho;
using static System.Double;
using Mu = Analys.Mutable;

namespace Analys.Test.Assets {
  public static class MutableTableCollection {
    public static Mu::Table<object> BoratTable = Mu::Table<object>.Build(
      Seq.From("day", "name", "kpi", "sold", "adt"),
      Seq.From(
        //
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", NaN, NaN, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        Seq.From<object>(1, "Glen", 1, 0, ""),
        //
        Seq.From<object>(2, "Fara", 1, 0, ""),
        Seq.From<object>(2, "Fara", 2, 0, ""),
        Seq.From<object>(2, "Fara", 3, 0, ""),
        Seq.From<object>(2, "Fara", 4, 0, ""),
        Seq.From<object>(2, "Fara", 5, 0, ""),
        Seq.From<object>(2, "Fara", 6, 0, ""),
        Seq.From<object>(2, "Fara", 7, 0, ""),
        Seq.From<object>(2, "Fara", 8, 0, ""),
        Seq.From<object>(2, "Fara", 9, 0, ""),
        Seq.From<object>(2, "Fara", 10, 0, ""),
        //
        Seq.From<object>(1, "Skye", 1, 0, ""),
        Seq.From<object>(1, "Skye", 9, 0, ""),
        Seq.From<object>(1, "Skye", 36, 0, ""),
        Seq.From<object>(1, "Skye", 84, 0, ""),
        Seq.From<object>(1, "Skye", 126, 0, ""),
        Seq.From<object>(1, "Skye", 126, 0, ""),
        Seq.From<object>(1, "Skye", 84, 0, ""),
        Seq.From<object>(1, "Skye", 36, 0, ""),
        Seq.From<object>(1, "Skye", 9, 0, ""),
        Seq.From<object>(1, "Skye", 1, 0, ""),
        //
        Seq.From<object>(2, "Kemp", 3, 0, ""),
        Seq.From<object>(2, "Kemp", 3, 0, ""),
        Seq.From<object>(2, "Kemp", 4, 0, ""),
        Seq.From<object>(2, "Kemp", 4, 0, ""),
        Seq.From<object>(2, "Kemp", 8, 0, ""),
        Seq.From<object>(2, "Kemp", 8, 0, ""),
        Seq.From<object>(2, "Kemp", 10, 0, ""),
        Seq.From<object>(2, "Kemp", 10, 0, ""),
        Seq.From<object>(2, "Kemp", 100, 0, ""),
        Seq.From<object>(2, "Kemp", 1000, 0, "")
      )
    );

    public static Mu::Table<object> DutyRosterTable = Mu::Table<object>.Build(
      Seq.From("day", "name", "served", "sold", "adt"),
      Seq.From(
        Seq.From<object>(1, "Taki", 70, 7, ""),
        Seq.From<object>(1, "Joyce", 66, 15, ""),
        Seq.From<object>(2, "Joyce", 86, 10, ""),
        Seq.From<object>(2, "Joyce", NaN, NaN, ""),
        Seq.From<object>(3, "Joyce", 96, 2, ""),
        Seq.From<object>(1, "Lance", 98, 15, ""),
        Seq.From<object>(1, "Lance", 66, 15, ""),
        Seq.From<object>(2, "Lance", 85, 12, ""),
        Seq.From<object>(2, "Lance", 63, 12, ""),
        Seq.From<object>(3, "Lance", NaN, NaN, ""),
        Seq.From<object>(1, "Naomi", 90, 14, ""),
        Seq.From<object>(1, "Naomi", 66, 9, ""),
        Seq.From<object>(2, "Naomi", NaN, NaN, ""),
        Seq.From<object>(2, "Naomi", 93, 16, ""),
        Seq.From<object>(3, "Naomi", 78, 8, "")
      )
    );
  }
}
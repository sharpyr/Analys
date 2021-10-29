using System;

namespace Analys.Test.Assets {
  public static partial class TableCollection {
    public static int ERR_NA = 1;

    public static Table<dynamic> FieldPerformanceTable = Table<dynamic>.Build(
      new[] { "date", "sid", "client", "product", "sold[a]", "rev[a]", "complaint" },
      new dynamic[,] {
                       { new DateTime(2021, 10, 5), "Fran", "Aaron", "Beer", 12D, 96.0, "-" },
                       { new DateTime(2021, 10, 5), "Fran", "Kyle", "Pizza", 5D, 400.0, "-" },
                       { new DateTime(2021, 10, 7), "Fran", "Aaron", "Wine", 9D, 360.0, "-" },
                       { new DateTime(2021, 10, 7), "Fran", "Kyle", "Steak", 5D, 450.0, "-" },
                       { new DateTime(2021, 10, 9), "Fran", "Dylan", "Soda", 16D, 80.0, "-" },
                       { new DateTime(2021, 10, 9), "Fran", "Dylan", "Snack", 8D, 48.0, "-" },
                       { null, null, null, null, null, null, null },
                       { new DateTime(2021, 10, 5), "Abel", "Carol", "Beer", 12D, 96.0, "-" },
                       { new DateTime(2021, 10, 5), "Abel", "Emma", "Pizza", 4D, 320.0, "-" },
                       { new DateTime(2021, 10, 7), "Abel", "Carol", "Wine", 8D, 320.0, "-" },
                       { new DateTime(2021, 10, 7), "Abel", "Emma", "Steak", 5D, 450.0, "-" },
                       { new DateTime(2021, 10, 9), "Abel", "Doris", "Soda", 16D, 80.0, "-" },
                       { new DateTime(2021, 10, 9), "Abel", "Doris", "Snack", 8D, 48.0, "-" },
                       { ERR_NA, ERR_NA, ERR_NA, ERR_NA, ERR_NA, ERR_NA, ERR_NA },
                       { new DateTime(2021, 10, 6), "Kate", "Billy", "Beer", 12D, 96.0, "-" },
                       { new DateTime(2021, 10, 6), "Kate", "Noah", "Pizza", 5D, 400.0, "-" },
                       { new DateTime(2021, 10, 8), "Kate", "Billy", "Wine", 6D, 240.0, "-" },
                       { new DateTime(2021, 10, 8), "Kate", "Noah", "Steak", 5D, 450.0, "-" },
                       { new DateTime(2021, 10, 9), "Kate", "Wayne", "Soda", 16D, 80.0, "-" },
                       { new DateTime(2021, 10, 9), "Kate", "Wayne", "Snack", 8D, 48.0, "-" },
                       { null, null, null, null, null, null, null },
                       { new DateTime(2021, 10, 6), "Gian", "Carol", "Beer", 12D, 96.0, "-" },
                       { new DateTime(2021, 10, 6), "Gian", "Emma", "Pizza", 5D, 400.0, "-" },
                       { new DateTime(2021, 10, 8), "Gian", "Carol", "Wine", 4D, 160.0, "-" },
                       { new DateTime(2021, 10, 8), "Gian", "Emma", "Steak", 5D, 450.0, "-" },
                       { new DateTime(2021, 10, 9), "Gian", "Doris", "Soda", 16D, 80.0, "-" },
                       { new DateTime(2021, 10, 9), "Gian", "Doris", "Snack", 8D, 48.0, "-" },
                       { ERR_NA, ERR_NA, ERR_NA, ERR_NA, ERR_NA, ERR_NA, ERR_NA },
                     }
    );
  }
}
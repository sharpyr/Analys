using Veho.List;
using Veho.NestedVector;

namespace Analys {
  public static class Converters {
    public static Table<T> MutableTableToTable<T>(this Mutable.Table<T> mutableTable) {
      var head = mutableTable.Head;
      var rows = mutableTable.Rows;
      return Table<T>.Build(
        head.ToArray(),
        rows.Map(row => row.ToArray()).ToArray().NestToMatrix()
      );
    }
  }
}
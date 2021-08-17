using Veho.Mutable.Matrix;
using Mu = Analys.Mutable;

namespace Analys.Convert {
  public static class Converters {
    public static Table<T> ToTable<T>(this Mu::Table<T> mutableTable) {
      var head = mutableTable.Head;
      var rows = mutableTable.Rows;
      return Table<T>.Build(
        head.ToArray(),
        rows.ToMatrix()
      );
    }
  }
}
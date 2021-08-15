using System.Collections.Generic;

namespace Analys.Mutable {
  public partial class Table<T> {
    public static Table<T> Build(List<string> head, List<List<T>> rows) => new Table<T> {
      Head = head,
      Rows = rows,
    };
    public static Table<T> Build(List<string> head) => new Table<T> {
      Head = head,
      Rows = new List<List<T>>(),
    };
  }
}
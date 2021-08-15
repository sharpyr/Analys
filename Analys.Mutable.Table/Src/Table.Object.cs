using System.Collections.Generic;

namespace Analys.Mutable {
  public class Table : Table<object> {
    public new static Table Build(List<string> head, List<List<object>> rows) => new Table {
      Head = head,
      Rows = rows,
    };
  }
}
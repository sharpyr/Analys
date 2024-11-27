using System.Collections.Generic;
using Veho.Sequence;

namespace Analys.Mutable {
  public partial class Table<T> {
    public Table<T> PushRow(List<T> vec) {
      Rows.Add(vec);
      return this;
    }
    public Table<T> PushColumn(List<T> vec) {
      Rows.IterateList((i, row) => row.Add(vec[i]));
      return this;
    }
  }
}
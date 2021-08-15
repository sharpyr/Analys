using System.Collections.Generic;
using Veho.List;

namespace Analys.Mutable {
  public partial class Table<T> {
    public Table<T> PushRow(List<T> vec) {
      this.Rows.Add(vec);
      return this;
    }
    public Table<T> PushColumn(List<T> vec) {
      this.Rows.Iterate((i, row) => row.Add(vec[i]));
      return this;
    }
  }
}
using Veho.Columns;
using Veho.Rows;

namespace Analys {
  public partial class Table<T> {
    public Table<T> PushRow(T[] vec) {
      Rows = Rows.PushRow(vec);
      return this;
    }
    public Table<T> PushColumn(T[] vec) {
      Rows = Rows.PushColumn(vec);
      return this;
    }
  }
}
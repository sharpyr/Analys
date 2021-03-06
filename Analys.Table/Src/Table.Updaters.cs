using Veho.Matrix.Columns;
using Veho.Matrix.Rows;

namespace Analys {
  public partial class Table<T> {
    public Table<T> PushRow(T[] vec) {
      this.Rows = this.Rows.PushRow(vec);
      return this;
    }
    public Table<T> PushColumn(T[] vec) {
      this.Rows = this.Rows.PushColumn(vec);
      return this;
    }
  }
}
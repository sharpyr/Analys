using System;
using Veho.Matrix;

namespace Analys {
  public partial class Table<T> {
    public Table<TO> Map<TO>(Func<T, TO> f) => Table<TO>.Build((string[]) this.Head.Clone(), this.Rows.Map(f));
  }
}
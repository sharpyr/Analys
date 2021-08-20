using System;
using Veho.Matrix;

namespace Analys {
  public partial class Table<T> {
    public Table<TO> Map<TO>(Func<T, TO> f) => Table<TO>.Build((string[]) Head.Clone(), Rows.Map(f));
  }
}
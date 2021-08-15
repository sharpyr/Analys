using System;
using Veho.List;
using Veho.Mutable.Matrix;

namespace Analys.Mutable {
  public partial class Table<T> {
    public Table<TO> Map<TO>(Func<T, TO> f) => Table<TO>.Build(this.Head.Map(x => x), this.Rows.Map(f));
  }
}
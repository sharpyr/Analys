using System;
using Veho.Mutable.Matrix;
using Veho.Sequence;

namespace Analys.Mutable {
  public partial class Table<T> {
    public Table<TO> Map<TO>(Func<T, TO> f) => Table<TO>.Build(Head.Map(x => x), Rows.Map(f));
  }
}
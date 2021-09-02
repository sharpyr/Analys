using System;
using System.Collections.Generic;
using Veho.Mutable.Columns;
using Veho.Mutable.Matrix;
using Veho.Sequence;

namespace Analys.Mutable {
  public partial class Crostab<T> {
    public Crostab<TO> Map<TO>(Func<T, TO> fn) => Crostab<TO>.Build(
      Side.Slice(),
      Head.Slice(),
      Rows.Map(fn)
    );
    public IEnumerable<(string, List<T>)> RowsIter() {
      for (int i = 0, hi = this.Height; i < hi; i++) yield return (this.Side[i], this.Rows[i]);
    }
    public IEnumerable<(string, List<T>)> ColumnsIter() {
      for (int j = 0, hi = this.Width; j < hi; j++) yield return (this.Head[j], this.Rows.Column(j));
    }
    public Crostab<TO> CastTo<TO>() => Crostab<TO>.Build(
      Side.Slice(),
      Head.Slice(),
      Rows.CastTo<T, TO>()
    );
  }
}
using System;
using System.Collections.Generic;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;

namespace Analys {
  public partial class Crostab<T> {
    public Crostab<TO> Map<TO>(Func<T, TO> fn) =>
      Crostab<TO>.Build((string[])Side.Clone(), (string[])Head.Clone(), Rows.Map(fn));
    public Crostab<TO> Map<TO>(Func<int, int, T, TO> fn) =>
      Crostab<TO>.Build((string[])Side.Clone(), (string[])Head.Clone(), Rows.Map(fn));

    public void Iterate(Action<string, string, T> action) {
      this.Rows.Iterate((i, j, cell) => action(this.Side[i], this.Head[j], cell));
    }
    public void Iterate(Action<int, int, string, string, T> action) {
      this.Rows.Iterate((i, j, cell) => action(i, j, this.Side[i], this.Head[j], cell));
    }
    public IEnumerable<(string, IEnumerable<T>)> RowsIntoIter() {
      for (int i = 0, hi = this.Height; i < hi; i++) yield return (this.Side[i], this.Rows.RowIntoIter(i));
    }
    public IEnumerable<(string, IEnumerable<T>)> ColumnsIntoIter() {
      for (int j = 0, hi = this.Width; j < hi; j++) yield return (this.Head[j], this.Rows.ColumnIntoIter(j));
    }
    public Crostab<TO> CastTo<TO>() => Crostab<TO>.Build(
      (string[])Side.Clone(),
      (string[])Head.Clone(),
      Rows.CastTo<T, TO>());
  }
}
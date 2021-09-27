using System.Collections.Generic;
using System.Text.RegularExpressions;
using Veho.Rows;
using Veho.Vector;

namespace Analys {
  public partial class Table<T> {
    public T[,] SelectBy(IReadOnlyList<string> headLabels) {
      var indices = headLabels.Map(this.CoIn);
      return this.Rows.SelectRows(indices);
    }
    public T[,] SelectOf(params string[] headLabels) {
      return this.SelectBy(headLabels);
    }
    public IEnumerable<T[]> IntoRowsIter(params string[] headLabels) {
      var indices = headLabels.Map(this.CoIn);
      return this.Rows.IntoRowsIter(indices);
    }
    public IEnumerable<T[]> IntoRowsIter(params Regex[] headLabels) {
      var indices = headLabels.Map(this.CoIn);
      return this.Rows.IntoRowsIter(indices);
    }
  }
}
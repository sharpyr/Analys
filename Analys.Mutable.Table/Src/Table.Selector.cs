using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Veho.Mutable.Rows;
using Veho.Sequence;

namespace Analys.Mutable {
  public partial class Table<T> {
    public IEnumerable<List<T>> SelectBy(IReadOnlyList<string> headLabels) {
      var indices = headLabels.Map(this.CoIn);
      return this.Rows.Select(row => row.SelectBy(indices));
    }
    public IEnumerable<List<T>> SelectOf(params string[] headLabels) {
      return this.SelectBy(headLabels);
    }
    public IEnumerable<List<T>> IntoRowsIter(params string[] headLabels) {
      var indices = headLabels.Map(this.CoIn);
      return this.Rows.IntoRowsIter(indices);
    }
    public IEnumerable<List<T>> IntoRowsIter(params Regex[] headLabels) {
      var indices = headLabels.Map(this.CoIn);
      return this.Rows.IntoRowsIter(indices);
    }
  }
}
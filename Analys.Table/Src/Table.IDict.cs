using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Veho.Columns;

namespace Analys {
  public partial class Table<T> {
    public IReadOnlyList<string> Keys => this.Head;
    public IReadOnlyList<T[]> Values => this.Rows.ColumnsIter().ToArray();
    public int Count => this.Width;
    public T[] this[string key] => this.Column(key);
    public bool Has(string key) { return this.CoIn(key) >= 0; }
    public bool TryLookup(string key, out T[] column) {
      var index = this.CoIn(key);
      column = index >= 0 ? this.Rows.Column(index) : null;
      return column != null;
    }
    public IEnumerator<(string key, T[] value)> GetEnumerator() {
      for (int i = 0, hi = this.Width; i < hi; i++) yield return (this.Head[i], this.Rows.Column(i));
    }
    IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
  }
}
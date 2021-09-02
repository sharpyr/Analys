using System.Collections.Generic;
using Veho.Mutable.Columns;
using Veho.Sequence;

namespace Analys.Mutable {
  public partial class Crostab<T> {
    public Crostab<T> WriteRow(string label, List<T> vec) {
      var x = this.RoIn(label);
      this.Rows[x].MutaZip(vec, (a, b) => b);
      return this;
    }
    public Crostab<T> AddRow(string label, List<T> vec) {
      this.Side.Add(label);
      this.Rows.Add(vec);
      return this;
    }
    public Crostab<T> UnshiftRow(string label, List<T> vec) {
      this.Side.Insert(0, label);
      this.Rows.Insert(0, vec);
      return this;
    }
    public Crostab<T> TopPostRow(string label) {
      var x = this.RoIn(label);
      if (x == 0) return this;
      var row = this.Rows[x];
      this.Side.RemoveAt(x);
      this.Rows.RemoveAt(x);
      return this.UnshiftRow(label, row);
    }
    public Crostab<T> WriteColumn(string label, List<T> vec) {
      var j = this.CoIn(label);
      this.Rows.WriteColumn(vec, j);
      return this;
    }
    public Crostab<T> AddColumn(string label, List<T> vec) {
      this.Head.Add(label);
      this.Rows.PushColumn(vec);
      return this;
    }
    public Crostab<T> UnshiftColumn(string label, List<T> vec) {
      this.Head.Insert(0, label);
      this.Rows.UnshiftColumn(vec);
      return this;
    }
    public Crostab<T> TopPostColumn(string label) {
      var y = this.CoIn(label);
      if (y == 0) return this;
      var column = this.Rows.Column(y);
      this.Head.RemoveAt(y);
      this.Rows.Iterate(row => row.RemoveAt(y));
      return this.UnshiftColumn(label, column);
    }
  }
}
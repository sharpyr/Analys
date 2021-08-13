using Veho.Columns;
using Veho.Rows;
using Veho.Vector;

namespace Analys {
  public partial class Crostab<T> {
    public Crostab<T> WriteRow(string label, T[] vec) {
      var x = this.RoIn(label);
      this.Rows.WriteRow(vec, x);
      return this;
    }
    public Crostab<T> PushRow(string label, T[] vec) {
      this.Side = this.Side.Push(label);
      this.Rows = this.Rows.PushRow(vec);
      return this;
    }
    public Crostab<T> UnshiftRow(string label, T[] vec) {
      this.Side = this.Side.Unshift(label);
      this.Rows = this.Rows.UnshiftRow(vec);
      return this;
    }
    public Crostab<T> WriteColumn(string label, T[] vec) {
      var j = this.CoIn(label);
      this.Rows.WriteColumn(vec, j);
      return this;
    }
    public Crostab<T> PushColumn(string label, T[] vec) {
      this.Head = this.Head.Push(label);
      this.Rows = this.Rows.PushColumn(vec);
      return this;
    }
    public Crostab<T> UnshiftColumn(string label, T[] vec) {
      this.Head = this.Head.Unshift(label);
      this.Rows = this.Rows.UnshiftColumn(vec);
      return this;
    }
  }
}
using Veho.Columns;
using Veho.Rows;
using Veho.Vector;

namespace Analys {
  public partial class Crostab<T> {
    public Crostab<T> WriteRow(string label, T[] vec) {
      var x = RoIn(label);
      Rows.WriteRow(vec, x);
      return this;
    }
    public Crostab<T> PushRow(string label, T[] vec) {
      Side = Side.Push(label);
      Rows = Rows.PushRow(vec);
      return this;
    }
    public Crostab<T> UnshiftRow(string label, T[] vec) {
      Side = Side.Unshift(label);
      Rows = Rows.UnshiftRow(vec);
      return this;
    }
    public Crostab<T> WriteColumn(string label, T[] vec) {
      var j = CoIn(label);
      Rows.WriteColumn(vec, j);
      return this;
    }
    public Crostab<T> PushColumn(string label, T[] vec) {
      Head = Head.Push(label);
      Rows = Rows.PushColumn(vec);
      return this;
    }
    public Crostab<T> UnshiftColumn(string label, T[] vec) {
      Head = Head.Unshift(label);
      Rows = Rows.UnshiftColumn(vec);
      return this;
    }
  }
}
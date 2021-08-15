using System;
using System.Collections.Generic;
using Veho.List;
using Veho.Mutable.Matrix;

namespace Analys.Mutable {
  public partial class Crostab<T> {
    public List<string> Side;
    public List<string> Head;
    public List<List<T>> Rows;
    public string Title = "";
    public (int height, int width) Size => this.Rows.Size();
    public int Height => this.Rows.Height();
    public int Width => this.Rows.Width();

    public T this[string s, string h] {
      get => this.Rows[this.RoIn(s)][this.CoIn(h)];
      set => this.Rows[this.RoIn(s)][this.CoIn(h)] = value;
    }

    public int RoIn(string side) => this.Side.IndexOf(side);
    public int CoIn(string head) => this.Head.IndexOf(head);
    public Crostab<TO> Map<TO>(Func<T, TO> fn) => Crostab<TO>.Build(
      this.Side.Map(x => x),
      this.Head.Map(x => x),
      this.Rows.Map(fn)
    );
    public Crostab<TO> CastTo<TO>() => Crostab<TO>.Build(
      this.Side.Map(x => x),
      this.Head.Map(x => x),
      this.Rows.CastTo<T, TO>()
    );
  }
}
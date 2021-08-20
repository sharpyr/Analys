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
    public (int height, int width) Size => Rows.Size();
    public int Height => Rows.Height();
    public int Width => Rows.Width();

    public T this[string s, string h] {
      get => Rows[RoIn(s)][CoIn(h)];
      set => Rows[RoIn(s)][CoIn(h)] = value;
    }

    public int RoIn(string side) => Side.IndexOf(side);
    public int CoIn(string head) => Head.IndexOf(head);
    public Crostab<TO> Map<TO>(Func<T, TO> fn) => Crostab<TO>.Build(
      Side.Map(x => x),
      Head.Map(x => x),
      Rows.Map(fn)
    );
    public Crostab<TO> CastTo<TO>() => Crostab<TO>.Build(
      Side.Map(x => x),
      Head.Map(x => x),
      Rows.CastTo<T, TO>()
    );
  }
}
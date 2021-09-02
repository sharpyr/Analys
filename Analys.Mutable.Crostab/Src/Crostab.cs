using System.Collections.Generic;
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
  }
}
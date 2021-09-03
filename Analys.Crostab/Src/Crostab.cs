using System;
using Veho.Matrix;

namespace Analys {
  public partial class Crostab<T> {
    public string[] Side;
    public string[] Head;
    public T[,] Rows;
    public string Title = "";
    public (int height, int width) Size => Rows.Size();
    public int Height => Rows.Height();
    public int Width => Rows.Width();

    public T this[string s, string h] {
      get => Rows[RoIn(s), CoIn(h)];
      set => Rows[RoIn(s), CoIn(h)] = value;
    }

    public int RoIn(string s) => Array.IndexOf(Side, s);
    public int CoIn(string h) => Array.IndexOf(Head, h);
  }
}
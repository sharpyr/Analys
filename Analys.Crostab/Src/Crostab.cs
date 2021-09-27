using System;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;

namespace Analys {
  public partial class Crostab<T> {
    public string[] Side;
    public string[] Head;
    public T[,] Rows;
    public string Title = "";
    public (int height, int width) Size => Rows.Size();
    public int Height => Rows.Height();
    public int Width => Rows.Width();

    public T this[string sideLabel, string headLabel] {
      get => Rows[RoIn(sideLabel), CoIn(headLabel)];
      set => Rows[RoIn(sideLabel), CoIn(headLabel)] = value;
    }
    public T this[int x, int y] {
      get => Rows[x, y];
      set => Rows[x, y] = value;
    }
    public int RoIn(string s) => Array.IndexOf(Side, s);
    public int CoIn(string h) => Array.IndexOf(Head, h);
    public T[] Row(string side) {
      var index = this.RoIn(side);
      return index >= 0 ? this.Rows.Row(index) : null;
    }
    public T[] Column(string head) {
      var index = this.RoIn(head);
      return index >= 0 ? this.Rows.Column(index) : null;
    }
  }
}
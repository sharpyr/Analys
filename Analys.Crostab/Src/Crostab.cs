using System;
using System.Collections.Generic;
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

    public T this[string s, string h] {
      get => Rows[RoIn(s), CoIn(h)];
      set => Rows[RoIn(s), CoIn(h)] = value;
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
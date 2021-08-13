using System;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;

namespace Analys {
  public partial class Table<T> {
    public string[] Head;
    public T[,] Rows;

    public (int height, int width) Size => this.Rows.Size();
    public int Height => this.Rows.Height();
    public int Width => this.Rows.Width();

    public T[] this[int x] => this.Rows.Row(x);

    public T this[int x, string h] {
      get => this.Rows[x, this.CoIn(h)];
      set => this.Rows[x, this.CoIn(h)] = value;
    }

    public T[] Column(string column) => this.Rows.Column(this.CoIn(column));

    public int CoIn(string h) => Array.IndexOf(this.Head, h);
  }
}
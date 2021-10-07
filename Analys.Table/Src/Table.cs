using System;
using System.Text.RegularExpressions;
using Veho.Columns;
using Veho.Matrix;
using Veho.Rows;
using Veho.Sequence;

namespace Analys {
  public partial class Table<T> : IDict<string, T[]> {
    public string[] Head;
    public T[,] Rows;

    public (int height, int width) Size => Rows.Size();
    public int Height => Rows.Height();
    public int Width => Rows.Width();

    public T[] this[int x] => Rows.Row(x);

    public T this[int x, string h] { get => Rows[x, CoIn(h)]; set => Rows[x, CoIn(h)] = value; }
    public T this[int x, int y] { get => Rows[x, y]; set => Rows[x, y] = value; }

    public T[] Column(string column) => Rows.Column(CoIn(column));

    public int CoIn(string h) => Array.IndexOf(Head, h);
    public int CoIn(Regex headRegex) => this.Head.FindIndex(headRegex.IsMatch);
  }
}
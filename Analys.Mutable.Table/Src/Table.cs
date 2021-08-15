using System;
using System.Collections.Generic;
using Analys.Mutable.Utils;
using Veho.Mutable.Columns;

namespace Analys.Mutable {
  public partial class Table<T> {
    public List<string> Head;
    public List<List<T>> Rows;

    public (int height, int width) Size => this.Rows.Size();
    public int Height => this.Rows.Height();
    public int Width => this.Rows.Width();

    public List<T> this[int x] => this.Rows[x];

    public T this[int x, int y] { get => this.Rows[x][y]; set => this.Rows[x][y] = value; }
    public T this[int x, string head] { get => this.Rows[x][this.CoIn(head)]; set => this.Rows[x][this.CoIn(head)] = value; }

    public List<T> Column(string column) => this.Rows.Column(this.CoIn(column));

    public int CoIn(string head) => this.Head.IndexOf(head);
  }
}
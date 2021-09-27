using System.Collections.Generic;
using System.Text.RegularExpressions;
using Analys.Mutable.Utils;
using Veho.Mutable.Columns;

namespace Analys.Mutable {
  public partial class Table<T> {
    public List<string> Head;
    public List<List<T>> Rows;

    public (int height, int width) Size => Rows.Size();
    public int Height => Rows.Height();
    public int Width => Rows.Width();

    public List<T> this[int x] => Rows[x];

    public T this[int x, int y] { get => Rows[x][y]; set => Rows[x][y] = value; }
    public T this[int x, string head] { get => Rows[x][CoIn(head)]; set => Rows[x][CoIn(head)] = value; }

    public List<T> Column(string column) => Rows.Column(CoIn(column));

    public int CoIn(string head) => Head.IndexOf(head);
    public int CoIn(Regex headRegex) => Head.FindIndex(headRegex.IsMatch);
  }
}
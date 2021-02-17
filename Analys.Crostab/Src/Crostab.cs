using System;
using Veho.Matrix;

namespace Analys.Crostab {
  public class Crostab<T> {
    public string[] Head;
    public string[] Side;
    public T[,] Rows;

    public static Crostab<T> Build(string[] head, string[] side, T[,] rows) {
      return new Crostab<T> {
        Head = head,
        Side = side,
        Rows = rows,
      };
    }

    public (int height, int width) Size => this.Rows.Size();
    public int Height => this.Rows.Height();
    public int Width => this.Rows.Width();

    public T this[string s, string h] => this.Rows[this.RoIn(s), this.CoIn(h)];

    public int CoIn(string h) => Array.IndexOf(this.Head, h);
    public int RoIn(string s) => Array.IndexOf(this.Side, s);
  }
}
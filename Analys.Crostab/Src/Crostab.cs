using System;
using Veho.Matrix;

namespace Analys.Crostab {
  public class Crostab : Crostab<object> {
    public new static Crostab Build(string[] side, string[] head, object[,] rows) => new Crostab {
      Side = side,
      Head = head,
      Rows = rows
    };
  }

  public class Crostab<T> {
    public string[] Side;
    public string[] Head;
    public T[,] Rows;

    public static Crostab<T> Build(string[] side, string[] head, T[,] rows) =>
      new Crostab<T> {
        Side = side,
        Head = head,
        Rows = rows,
      };

    public (int height, int width) Size => this.Rows.Size();
    public int Height => this.Rows.Height();
    public int Width => this.Rows.Width();

    public T this[string s, string h] => this.Rows[this.RoIn(s), this.CoIn(h)];

    public int RoIn(string s) => Array.IndexOf(this.Side, s);
    public int CoIn(string h) => Array.IndexOf(this.Head, h);

    public Crostab<TO> Map<TO>(Func<T, TO> fn) =>
      Crostab<TO>.Build((string[]) this.Side.Clone(), (string[]) this.Head.Clone(), this.Rows.Map(fn));
    public Crostab<TO> CastTo<TO>() => Crostab<TO>.Build((string[]) this.Side.Clone(), (string[]) this.Head.Clone(),
      this.Rows.CastTo<T, TO>());
  }
}
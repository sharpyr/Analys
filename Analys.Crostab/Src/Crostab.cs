using System;
using Veho.Matrix;

namespace Analys {
  public class Crostab : Crostab<object> {
    public new static Crostab Build(string[] side, string[] head, object[,] rows) => new Crostab {
      Side = side,
      Head = head,
      Rows = rows
    };
  }

  public partial class Crostab<T> {
    public string[] Side;
    public string[] Head;
    public T[,] Rows;
    public string Title = "";
    public (int height, int width) Size => this.Rows.Size();
    public int Height => this.Rows.Height();
    public int Width => this.Rows.Width();

    public T this[string s, string h] {
      get => this.Rows[this.RoIn(s), this.CoIn(h)];
      set => this.Rows[this.RoIn(s), this.CoIn(s)] = value;
    }

    public int RoIn(string s) => Array.IndexOf(this.Side, s);
    public int CoIn(string h) => Array.IndexOf(this.Head, h);
    public Crostab<TO> Map<TO>(Func<T, TO> fn) =>
      Crostab<TO>.Build((string[]) this.Side.Clone(), (string[]) this.Head.Clone(), this.Rows.Map(fn));
    public Crostab<TO> CastTo<TO>() => Crostab<TO>.Build((string[]) this.Side.Clone(), (string[]) this.Head.Clone(),
      this.Rows.CastTo<T, TO>());
  }
}
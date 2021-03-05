using System;
using Typen;
using Veho.Matrix;

namespace Analys {
  public static class CrostabFactory {
    public static Crostab<T> ToCrostab<T>(this DataGram<T> dataGram) => Crostab<T>.Build(
      dataGram.Side,
      dataGram.Head,
      dataGram.Rows.NestToMatrix()
    );
    public static Crostab<TO> ToCrostab<T, TO>(this DataGram<T> dataGram, Func<T, TO> func = null) => Crostab<TO>.Build(
      dataGram.Side,
      dataGram.Head,
      dataGram.Rows.NestToMatrix(func ?? Conv.Cast<T, TO>)
    );
  }

  public partial class Crostab<T> {
    public static Crostab<T> Build(string[] side, string[] head, T[,] rows) => new Crostab<T> {
      Side = side,
      Head = head,
      Rows = rows,
    };
  }
}
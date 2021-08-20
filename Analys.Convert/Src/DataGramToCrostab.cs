using System;
using Typen;
using Veho.NestedVector;

namespace Analys {
  public static class DataGramToCrostab {
    public static Crostab<T> ToCrostab<T>(this DataGram<T> dataGram) => Crostab<T>.Build(
      dataGram.Side,
      dataGram.Head,
      dataGram.Rows.NestToMatrix()
    );
    public static Crostab<TO> ToCrostab<T, TO>(this DataGram<T> dataGram, Func<T, TO> conv = null) => Crostab<TO>.Build(
      dataGram.Side,
      dataGram.Head,
      dataGram.Rows.NestToMatrix(conv ?? Conv.Cast<T, TO>)
    );
  }
}
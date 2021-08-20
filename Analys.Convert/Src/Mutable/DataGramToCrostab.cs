using System;
using Typen;
using Veho.Mutable.Matrix;
using Mu = Analys.Mutable;

namespace Analys.Mutable {
  public static class DataGramToCrostab {
    public static Mu::Crostab<T> ToCrostab<T>(this Mu::DataGram<T> dataGram) => Mu::Crostab<T>.Build(
      dataGram.Side,
      dataGram.Head,
      dataGram.Rows
    );
    public static Mu::Crostab<TO> ToCrostab<T, TO>(this Mu::DataGram<T> dataGram, Func<T, TO> conv = null) => Mu::Crostab<TO>.Build(
      dataGram.Side,
      dataGram.Head,
      dataGram.Rows.Map(conv ?? Conv.Cast<T, TO>)
    );
  }
}
using System.Collections.Generic;
using Veho.Mutable;

namespace Analys.Mutable {
  public partial class Crostab<T> {
    public static Crostab<T> Build(List<string> side, List<string> head, List<List<T>> rows) => new Crostab<T> {
      Side = side,
      Head = head,
      Rows = rows,
    };
    public static Crostab<T> Build(List<string> side, List<string> head) => new Crostab<T> {
      Side = side,
      Head = head,
      Rows = Mat.Init<T>(side.Count, head.Count, (i, j) => default),
    };
  }
}
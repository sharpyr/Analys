using Veho;

namespace Analys {
  public partial class Crostab<T> {
    public static Crostab<T> Build(string[] side, string[] head, T[,] rows) => new Crostab<T> {
      Side = side,
      Head = head,
      Rows = rows,
    };
    public static Crostab<T> Build(string[] side, string[] head) => new Crostab<T> {
      Side = side,
      Head = head,
      Rows = (side.Length, head.Length).Init<T>((i, j) => default),
    };
  }
}
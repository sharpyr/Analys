namespace Analys {
  public static class CrostabFactory {
    public static Crostab<T> ToCrostab<T>(this (string[] side, string[] head, T[,] rows) tuple) => Crostab<T>.Build(
      tuple.side,
      tuple.head,
      tuple.rows
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
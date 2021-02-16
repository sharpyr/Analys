namespace Analys.Crostab {
  public class Crostab<T> {
    public string[] Head;
    public string[] Side;
    public T[,] Rows;

    public static Crostab<T> Build(string[] head, string[] side, T[,] rows) {
      return new Crostab<T>() {
        Head = head,
        Side = side,
        Rows = rows,
      };
    }
  }
}
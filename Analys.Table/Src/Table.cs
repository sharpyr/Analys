namespace Analys.Table {
  public class Table<T> {
    public string[] Head;
    public T[,] Rows;

    public static Table<T> Build(string[] head, T[,] rows) {
      return new Table<T>() {
        Head = head,
        Rows = rows,
      };
    }
  }
}
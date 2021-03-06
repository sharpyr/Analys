namespace Analys {
  public partial class Table<T> {
    public static Table<T> Build(string[] head, T[,] rows) => new Table<T> {
      Head = head,
      Rows = rows,
    };
    public static Table<T> Build(string[] head) => new Table<T> {
      Head = head,
      Rows = new T[0, head.Length],
    };
  }
}
namespace Analys {
  public class Table : Table<object> {
    public new static Table Build(string[] head, object[,] rows) => new Table {
      Head = head,
      Rows = rows,
    };
  }
}
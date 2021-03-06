namespace Analys {
  public class Crostab : Crostab<object> {
    public new static Crostab Build(string[] side, string[] head, object[,] rows) => new Crostab {
      Side = side,
      Head = head,
      Rows = rows
    };
  }
}
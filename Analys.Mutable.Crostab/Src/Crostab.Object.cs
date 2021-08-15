using System.Collections.Generic;

namespace Analys.Mutable {
  public class Crostab : Crostab<object> {
    public new static Crostab Build(List<string> side, List<string> head, List<List<object>> rows) => new Crostab {
      Side = side,
      Head = head,
      Rows = rows
    };
  }
}
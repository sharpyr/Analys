using System.Collections.Generic;
using System.Linq;
using Veho.Sequence;

namespace Analys.Mutable {
  public partial class Crostab<T> {
    public Crostab<T> SelectBy(IReadOnlyList<string> side, IReadOnlyList<string> head) {
      var sideIndices = side.Map(x => this.Side.IndexOf(x));
      var headIndices = head.Map(x => this.Head.IndexOf(x));
      return Build(
        side.ToList(),
        head.ToList(),
        this.Rows.SelectListBy(sideIndices).Map(row => row.SelectListBy(headIndices))
      );
    }
  }
}
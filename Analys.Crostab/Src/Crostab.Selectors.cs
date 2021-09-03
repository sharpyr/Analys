using System.Collections.Generic;
using System.Linq;
using Veho.Matrix;
using Veho.Vector;


namespace Analys {
  public partial class Crostab<T> {
    public Crostab<T> SelectBy(IReadOnlyList<string> side, IReadOnlyList<string> head) {
      var sideIndices = side.Map(x => this.Side.IndexOf(x));
      var headIndices = head.Map(x => this.Head.IndexOf(x));
      return Crostab<T>.Build(
        side.ToArray(),
        head.ToArray(),
        this.Rows.SelectBy(sideIndices, headIndices)
      );
    }
  }
}
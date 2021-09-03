using System;
using System.Collections.Generic;
using System.Linq;
using Veho.Mutable.Matrix;
using Veho.Sequence;
using Mu = Veho.Mutable.Matrix;

namespace Analys.Mutable {
  public static class SymmetricCrostab {
    public static Crostab<T> SelectBy<T>(Crostab<T> crostab, IReadOnlyList<int> indices) {
      return Crostab<T>.Build(
        crostab.Side.SelectBy(indices),
        crostab.Head.SelectBy(indices),
        Mu::SymmetricMatrix.SelectBy(crostab.Rows, indices)
      );
    }
    public static Crostab<T> SelectBy<T>(Crostab<T> crostab, IReadOnlyList<string> labels) {
      var indices = labels.Map(x => crostab.Side.IndexOf(x));
      return Crostab<T>.Build(
        labels.ToList(),
        labels.ToList(),
        crostab.Rows.SelectBy(indices).Map(row => row.SelectBy(indices))
      );
    }
    public static Crostab<T> UpperTriangular<T>(Crostab<T> crostab) {
      return Crostab<T>.Build(
        crostab.Side.Slice(),
        crostab.Head.Slice(),
        Mu::SymmetricMatrix.UpperTriangular(crostab.Rows)
      );
    }
    public static Crostab<T> LowerTriangular<T>(Crostab<T> crostab) {
      return Crostab<T>.Build(
        crostab.Side.Slice(),
        crostab.Head.Slice(),
        Mu::SymmetricMatrix.LowerTriangular(crostab.Rows)
      );
    }
    public static IEnumerable<Crostab<T>> IntersectionalBlocks<T>(this Crostab<T> crostab, T signal) where T : IEquatable<T> {
      return crostab.Rows
                    .IntersectionalIndices(signal)
                    .Select(intersectionalIndices => SymmetricCrostab.SelectBy(crostab, intersectionalIndices.ToList()));
    }
  }
}
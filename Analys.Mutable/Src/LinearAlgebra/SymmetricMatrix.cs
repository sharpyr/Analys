using System;
using System.Collections.Generic;
using System.Linq;
using Veho.Sequence;
using Veho.Mutable.LinearAlgebra;
using Mu = Veho.Mutable.LinearAlgebra;

namespace Analys.Mutable.LinearAlgebra {
  public static class SymmetricMatrix {
    public static Crostab<T> SelectBy<T>(Crostab<T> crostab, IReadOnlyList<int> indices) {
      var labels = crostab.Side.SelectBy(indices);
      var rows = Mu::SymmetricMatrix.SelectBy(crostab.Rows, indices);
      return Crostab<T>.Build(labels.Slice(), labels.Slice(), rows);
    }

    public static IEnumerable<Crostab<T>> IntersectionalBlocks<T>(this Crostab<T> crostab, T signal) where T : IEquatable<T> {
      var rowSkipper = Skipper<List<T>>.Build(crostab.Rows);
      foreach (var index in rowSkipper.IntoIndexIter()) {
        var intersectionalIndices = crostab.Rows.FindIntersectional(index, signal).ToList();
        rowSkipper.AcquireIndices(intersectionalIndices);
        if (intersectionalIndices.Count <= 1) continue;
        // common.Deco().Says(index.ToString());
        yield return SymmetricMatrix.SelectBy(crostab, intersectionalIndices);
      }
    }
  }
}
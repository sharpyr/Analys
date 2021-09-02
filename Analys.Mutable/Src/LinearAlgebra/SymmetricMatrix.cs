using System;
using System.Collections.Generic;
using System.Linq;
using Veho.Sequence;
using Veho.Mutable.LinearAlgebra;
using MLA = Veho.Mutable.LinearAlgebra;

namespace Analys.Mutable.LinearAlgebra {
  public static class SymmetricMatrix {
    public static IEnumerable<Crostab<T>> IntersectionalBlocks<T>(this Crostab<T> crostab, T signal) where T : IEquatable<T> {
      var rowSkipper = Skipper<List<T>>.Build(crostab.Rows);
      foreach (var index in rowSkipper.IntoIndexIter()) {
        var intersectionalIndices = crostab.Rows.FindIntersectional(index, signal).ToList();
        rowSkipper.AcquireIndices(intersectionalIndices);
        if (intersectionalIndices.Count <= 1) continue;
        // common.Deco().Says(index.ToString());
        var labels = crostab.Side.SelectBy(intersectionalIndices);
        var rows = MLA::SymmetricMatrix.SelectBy(crostab.Rows, intersectionalIndices);
        yield return Crostab<T>.Build(labels.Slice(), labels.Slice(), rows);
      }
    }
  }
}
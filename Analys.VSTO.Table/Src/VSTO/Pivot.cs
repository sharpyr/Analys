using System;
using System.Collections.Generic;

namespace Analys.VSTO {
  public class Pivot<TAccum, TSample> : DataGram<TAccum> {
    public Func<TAccum, TSample, TAccum> Accumulator;
    public Pivot<TAccum, TSample> Record<TSource>(IReadOnlyList<string> sideSamples,
                                                  IReadOnlyList<string> headSamples,
                                                  IReadOnlyList<TSource> fieldSamples,
                                                  Func<TSource, TSample> parser) {
      for (int i = 0, hi = sideSamples.Count; i < hi; i++) {
        var side = sideSamples[i] ?? "";
        var head = headSamples[i] ?? "";
        var value = parser(fieldSamples[i]);
        Note(head, side, value);
      }
      return this;
    }
    public Pivot<TAccum, TSample> Record(IReadOnlyList<string> sideSamples,
                                         IReadOnlyList<string> headSamples,
                                         IReadOnlyList<TSample> fieldSamples) {
      for (int i = 0, hi = sideSamples.Count; i < hi; i++) {
        var side = sideSamples[i] ?? "";
        var head = headSamples[i] ?? "";
        var value = fieldSamples[i];
        Note(head, side, value);
      }
      return this;
    }
    private TAccum Note(string head, string side, TSample value) {
      var x = IndexSide(side);
      var y = IndexHead(head);
      var row = Rows[x];
      return row[y] = Accumulator(row[y], value);
    }
  }
}
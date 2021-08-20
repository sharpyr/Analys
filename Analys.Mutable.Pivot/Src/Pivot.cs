using System;
using System.Collections.Generic;
using Veho.Mutable.Matrix;

namespace Analys.Mutable {
  public class Pivot<TAccum, TSample> : DataGram<TAccum> {
    public (int side, int head, int field) Indexes;
    public Func<TAccum, TSample, TAccum> Accumulator;

    public Pivot<TAccum, TSample> Record(List<List<TSample>> samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var sample = samples[i];
        var side = sample[Indexes.side].ToString();
        var head = sample[Indexes.head].ToString();
        var value = sample[Indexes.field];
        Note(head, side, value);
      }
      return this;
    }
    public Pivot<TAccum, TSample> Record<TSource>(List<List<TSource>> samples, Func<TSource, TSample> parser) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var sample = samples[i];
        var side = sample[Indexes.side].ToString();
        var head = sample[Indexes.head].ToString();
        var value = parser(sample[Indexes.field]);
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
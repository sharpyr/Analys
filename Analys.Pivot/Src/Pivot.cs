﻿using System;
using Veho.Matrix;

namespace Analys {
  public class Pivot<TAccum, TSample> : DataGram<TAccum> {
    public (int side, int head, int field) Indexes;
    public Func<TAccum, TSample, TAccum> Accumulator;

    public Pivot<TAccum, TSample> Record(TSample[,] samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, Indexes.side].ToString();
        var head = samples[i, Indexes.head].ToString();
        var value = samples[i, Indexes.field];
        Note(head, side, value);
      }
      return this;
    }
    public Pivot<TAccum, TSample> Record<TSource>(TSource[,] samples, Func<TSource, TSample> parser) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, Indexes.side].ToString();
        var head = samples[i, Indexes.head].ToString();
        var value = parser(samples[i, Indexes.field]);
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
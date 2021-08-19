using System;
using Veho.Matrix;

namespace Analys {
  public class Pivot<TSample, TAccum> : DataGram<TAccum> {
    public (int side, int head, int field) Indexes;
    public Func<TAccum, TSample, TAccum> Accumulator;

    public static Pivot<TSample, TAccum> Build((int side, int head, int field) fieldIndexes, Func<TAccum> initializer, Func<TAccum, TSample, TAccum> accumulator) {
      return new Pivot<TSample, TAccum> {
        Indexes = fieldIndexes,
        Accumulator = accumulator,
        Init = initializer,
        Side = new string[] { },
        Head = new string[] { },
        Rows = new TAccum[][] { },
      };
    }

    public Pivot<TSample, TAccum> Record(TSample[,] samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, this.Indexes.side].ToString();
        var head = samples[i, this.Indexes.head].ToString();
        var value = samples[i, this.Indexes.field];
        this.Note(head, side, value);
      }
      return this;
    }
    public Pivot<TSample, TAccum> Record<TSource>(TSource[,] samples, Func<TSource, TSample> parser) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, this.Indexes.side].ToString();
        var head = samples[i, this.Indexes.head].ToString();
        var value = parser(samples[i, this.Indexes.field]);
        this.Note(head, side, value);
      }
      return this;
    }
    private TAccum Note(string head, string side, TSample value) {
      var x = this.IndexSide(side);
      var y = this.IndexHead(head);
      var row = this.Rows[x];
      return row[y] = this.Accumulator(row[y], value);
    }
  }
}
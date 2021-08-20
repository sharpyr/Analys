using System;
using Analys.Types;
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

    public static Pivot<double, IStat> Build((int side, int head, int field) fieldIndexes, Func<IStat> initializer) {
      return new Pivot<double, IStat> {
        Indexes = fieldIndexes,
        Accumulator = StatExt.Record,
        Init = initializer,
        Side = new string[] { },
        Head = new string[] { },
        Rows = new IStat[][] { },
      };
    }

    public Pivot<TSample, TAccum> Record(TSample[,] samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, Indexes.side].ToString();
        var head = samples[i, Indexes.head].ToString();
        var value = samples[i, Indexes.field];
        Note(head, side, value);
      }
      return this;
    }
    public Pivot<TSample, TAccum> Record<TSource>(TSource[,] samples, Func<TSource, TSample> parser) {
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
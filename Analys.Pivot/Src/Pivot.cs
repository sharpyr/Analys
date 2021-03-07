using System;
using System.Collections.Generic;
using Analys.Pivot;
using Analys.Types;
using Typen;
using Veho.Matrix;

namespace Analys {
  public class Pivot<TA, T, TP> : DataGram<TP> {
    private int _sideIndex;
    private int _headIndex;
    private int _fieldIndex;
    private Func<TP, T, TP> _accum;
    private Func<TA, T> _conv;


    public static Pivot<dynamic, dynamic, dynamic> Build(int side, int head, int field, Pivoted mode) {
      var (init, accum, conv) = mode.ModeToPreset();
      return new Pivot<dynamic, dynamic, dynamic> {
        _sideIndex = side,
        _headIndex = head,
        _fieldIndex = field,
        _accum = (target, value) => accum(target, value),
        _conv = some => conv(some),
        Init = () => init(),
        Side = new string[] { },
        Head = new string[] { },
        Rows = new dynamic[][] { },
      };
    }

    public Pivot<TA, T, TP> Record(TA[,] samples, Func<TA, T> conv = null) {
      if (conv == null) conv = _conv ?? Conv.Cast<TA, T>;
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, _sideIndex].ToString();
        var head = samples[i, _headIndex].ToString();
        var value = conv(samples[i, _fieldIndex]);
        this.Note(head, side, value);
      }
      return this;
    }

    // public Pivot<T, TP> Record(object[,] samples, Func<object, T> conv = null) {
    //   if (conv == null) conv = Conv.Cast<object, T>;
    //   for (int i = 0, h = samples.Height(); i < h; i++) {
    //     var side = samples[i, _sideIndex].ToString();
    //     var head = samples[i, _headIndex].ToString();
    //     var value = samples[i, _fieldIndex];
    //     this.Note(head, side, conv(value));
    //   }
    //   return this;
    // }
    private TP Note(string head, string side, T value) {
      var x = this.IndexSide(side);
      var y = this.IndexHead(head);
      var row = Rows[x];
      return row[y] = _accum(row[y], value);
    }
    private TP Note(IReadOnlyList<object> sample) {
      var side = sample[_sideIndex].ToString();
      var head = sample[_headIndex].ToString();
      var value = sample[_fieldIndex].Cast<object, T>();
      return this.Note(head, side, value);
    }
  }
}
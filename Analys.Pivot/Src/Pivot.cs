using System;
using System.Collections.Generic;
using Analys.Pivot;
using Analys.Types;
using Typen;
using Veho.Matrix;

namespace Analys {
  public class Pivot<T, TP> : DataGram<TP> {
    private int _sideIndex;
    private int _headIndex;
    private int _fieldIndex;
    private Func<TP, T, TP> _accum;

    public static Pivot<dynamic, dynamic> Build(int side, int head, int field, PivotMode mode) {
      var (init, accum) = mode.ModeToPreset();
      return new Pivot<dynamic, dynamic> {
        _sideIndex = side,
        _headIndex = head,
        _fieldIndex = field,
        _accum = (target, value) => accum(target, value),
        Init = () => init(),
        Side = new string[] { },
        Head = new string[] { },
        Rows = new dynamic[][] { },
      };
    }

    public Pivot<T, TP> Record(T[,] samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, _sideIndex].ToString();
        var head = samples[i, _headIndex].ToString();
        var value = samples[i, _fieldIndex];
        this.Note(head, side, value);
      }
      return this;
    }
    public Pivot<T, TP> Record(object[,] samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, _sideIndex].ToString();
        var head = samples[i, _headIndex].ToString();
        var value = samples[i, _fieldIndex].Cast<object, T>();
        this.Note(head, side, value);
      }
      return this;
    }
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
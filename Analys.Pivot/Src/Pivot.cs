using System;
using Analys.Types;
using Typen;
using Veho.Matrix;
using Veho.Vector;
using Inits = Analys.Types.Inits;

namespace Analys {
  public class Pivot<T, TP> {
    private int _side;
    private int _head;
    private int _field;
    private Func<TP, T, TP> _accum;
    private DataGram<TP> _dataGram;

    public static Pivot<dynamic, dynamic> Build(int side, int head, int field, PivotMode mode) {
      var modeName = Factor<PivotMode>.Label(mode);
      Console.WriteLine(modeName);
      // (dynamic init ,dynamic accum)=Presets
      return new Pivot<dynamic, dynamic> {
        _side = side,
        _head = head,
        _field = field,
        _accum = (Func<dynamic, dynamic, dynamic>) typeof(Accumulators).GetMethod(modeName)?.Invoke(null, null),
        _dataGram = DataGram<dynamic>.Build(
          (Func<dynamic>) typeof(Inits).GetMethod(modeName)?.Invoke(null, null)
        )
      };
    }
    public static Pivot<T, TP> Build(int side, int head, int field, Func<TP> init, Func<TP, T, TP> accum) =>
      new Pivot<T, TP> {
        _side = side,
        _head = head,
        _field = field,
        _accum = accum,
        _dataGram = DataGram<TP>.Build(init)
      };
    public (string[] side, string[] head, TP[,] rows) ToTuple() => this._dataGram.ToTuple();
    public (string[] side, string[] head, TO[,] rows) ToTuple<TO>() => this._dataGram.ToTuple<TO>();
    public Pivot<T, TP> Record(object[][] samples) {
      samples.Iterate(row => this.Note(row));
      return this;
    }
    public Pivot<T, TP> Record(object[,] samples) {
      for (int i = 0, h = samples.Height(); i < h; i++) {
        var side = samples[i, _side].ToString();
        var head = samples[i, _head].ToString();
        var value = samples[i, _field].Cast<object, T>();
        this.Note(head, side, value);
      }
      return this;
    }
    private TP Note(string head, string side, T value) {
      var x = _dataGram.IndexSide(side);
      var y = _dataGram.IndexHead(head);
      var row = _dataGram.Rows[x];
      return row[y] = _accum(row[y], value);
    }
    private TP Note(object[] sample) {
      var side = sample[_side].ToString();
      var head = sample[_head].ToString();
      var value = sample[_field].Cast<object, T>();
      return this.Note(head, side, value);
    }
  }
}
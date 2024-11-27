using System;
using System.Collections.Generic;
using Veho;
using Veho.Mutable.Columns;
using Veho.Mutable.Matrix;

namespace Analys.Mutable {
  public class DataGram<T> {
    public List<string> Side;
    public List<string> Head;
    public List<List<T>> Rows;
    public Func<T> Init;

    public static DataGram<T> Build(Func<T> init) => new DataGram<T> {
                                                                       Side = new List<string>(),
                                                                       Head = new List<string>(),
                                                                       Rows = new List<List<T>>(),
                                                                       Init = init
                                                                     };
    public int IndexSide(string x) {
      var ri = Side.IndexOf(x);
      if (ri >= 0) return ri;
      var row = Seq.Init(Rows.Width(), j => Init());
      Rows.Add(row);
      Side.Add(x);
      return Side.Count - 1;
    }
    public int IndexHead(string y) {
      var ci = Head.IndexOf(y);
      if (ci >= 0) return ci;
      var col = Seq.Init(Rows.Height(), i => Init());
      Rows.PushColumn(col);
      Head.Add(y);
      return Head.Count - 1;
    }
  }
}
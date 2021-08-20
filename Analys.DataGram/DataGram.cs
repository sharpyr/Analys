using System;
using Veho;
using Veho.NestedVector;
using Veho.Vector;

namespace Analys {
  public class DataGram<T> {
    public string[] Side;
    public string[] Head;
    public T[][] Rows;
    public Func<T> Init;

    // public DataGram<T>(string[] side, string[] head, T[][] rows, Func<T> init) {
    //   
    // }
    public static DataGram<T> Build(Func<T> init) => new DataGram<T> {
      Side = new string[] { },
      Head = new string[] { },
      Rows = new T[][] { },
      Init = init
    };
    public int IndexSide(string x) {
      var ri = Side.IndexOf(x);
      if (ri >= 0) return ri;
      Ext.PushRow(ref Rows, Vec.Init(Rows.Width(), j => Init()));
      return ri + Vec.Push(ref Side, x);
    }
    public int IndexHead(string y) {
      var ci = Head.IndexOf(y);
      if (ci >= 0) return ci;
      Ext.PushColumn(ref Rows, Vec.Init(Rows.Height(), i => Init()));
      return ci + Vec.Push(ref Head, y);
    }
  }
}
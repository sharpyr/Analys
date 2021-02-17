using System;

namespace Analys.Table {
  public class DataGram<T> {
    public string[] Side;
    public string[] Head;
    public string[,] Rows;
    public Func<T> Init;
    public int IndexHead(string y) {
      var ci = Array.IndexOf(this.Head, y);
      if (ci >= 0) return ci;
      return 0;
    }
  }
}
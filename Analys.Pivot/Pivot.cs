using System;
using System.Collections.Generic;

namespace Analys.Pivot {
  public class Pivot<TS,TH,T> {
    public Dictionary<int, Func<object, TS>> Side;
    public Dictionary<int, Func<object, TH>> Head;
    
  }
}
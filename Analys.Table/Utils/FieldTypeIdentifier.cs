using Typen;
using Veho.Columns;
using Veho.Vector;

namespace Analys.Utils {
  public enum Datatype {
    Num,
    Str,
    Boo,
  }

  public static class FieldTypeIdentifier {
    public static Datatype[] Types(this object[,] matrix) {
      return matrix.MapColumns(col => { return col.Every(x => x.IsNumeric()) ? Datatype.Num : Datatype.Str; });
    }

    // public static Type[] Types(this object[,] matrix, int depth) { }
  }
}
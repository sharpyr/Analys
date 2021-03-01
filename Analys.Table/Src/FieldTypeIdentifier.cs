using Typen.Numeral;
using Veho.Matrix.Columns;
using Veho.Vector;

namespace Analys.Table {
  public enum Datatype {
    Num,
    Str,
    Boo,
  }

  public static class FieldTypeIdentifier {
    public static Datatype[] Types(this object[,] matrix) {
      return matrix.MapColumns(col => {
        return col.Every(x => x.IsNumeric()) ? Datatype.Num : Datatype.Str;
      });
    }

    // public static Type[] Types(this object[,] matrix, int depth) { }
  }
}
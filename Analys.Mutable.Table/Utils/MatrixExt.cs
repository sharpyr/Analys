using System.Collections.Generic;

namespace Analys.Mutable.Utils {
  public static class MatrixExt {
    public static int Height<T>(this List<List<T>> matrix) => matrix.Count;
    public static int Width<T>(this List<List<T>> matrix) => matrix.Count > 0 ? matrix[0].Count : 0;
    public static (int h, int w) Size<T>(this List<List<T>> matrix) => (matrix.Height(), matrix.Width());
  }
}
using Veho.Matrix;
using Veho.Vector;

namespace Analys {
  public static class Ext {
    public static T[][] PushRow<T>(this T[][] matrix, T[] row) =>
      matrix.Push(row);
    public static T[][] PushColumn<T>(this T[][] matrix, T[] column) =>
      matrix.Zip(column, (row, x) => row.Push(x));
    public static int PushRow<T>(ref T[][] matrix, T[] row) => Vec.Push(ref matrix, row);
    public static int PushColumn<T>(ref T[][] matrix, T[] column) =>
      Vec.MutaZip(ref matrix, column, (row, x) => row.Push(x)).Width();
  }
}
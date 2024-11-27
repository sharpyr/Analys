namespace Analys.VSTO {
  public static class Converters {
    public static AlgebraicTable<T> ToAlgebraicTable<T>(this Table<T> table) {
      return new AlgebraicTable<T> { Head = table.Head, Rows = table.Rows };
    }
  }
}
using Veho.Tuple;

namespace Analys {
  public static class TableIndexes {
    public static (int side, int head, int field) GetIndexes<T>(this Table<T> table, (string side, string head, string field) fields) => fields.To(table.CoIn);
  }
}
using Veho.Tuple;

namespace Analys.Mutable {
  public partial class Table<T> {
    public (int side, int head, int field) GetIndexes((string side, string head, string field) fields) => fields.Map(this.CoIn);
  }
}
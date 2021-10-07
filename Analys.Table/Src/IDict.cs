using System.Collections.Generic;

namespace Analys {
  public interface IDict<TKey, TValue> : IEnumerable<(TKey key, TValue value )> {
    IReadOnlyList<TKey> Keys { get; }
    IReadOnlyList<TValue> Values { get; }
    int Count { get; }
    TValue this[TKey key] { get; }
    bool Has(string key);
    bool TryLookup(TKey key, out TValue value);
  }
}
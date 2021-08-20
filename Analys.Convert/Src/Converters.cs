using System;
using System.Collections.Generic;
using Veho;
using Veho.List;
using Veho.Mutable.Matrix;
using Mu = Analys.Mutable;

namespace Analys {
  public static class Converters {
    public static Table<T> ToTable<T>(this Mu::Table<T> mutableTable) {
      var head = mutableTable.Head;
      var rows = mutableTable.Rows;
      return Table<T>.Build(
        head.ToArray(),
        rows.ToMatrix()
      );
    }
    public static Crostab<T> ToCrostab<T>(this Mu::Crostab<T> mutableTable) {
      var head = mutableTable.Head;
      var side = mutableTable.Side;
      var rows = mutableTable.Rows;
      return Crostab<T>.Build(
        side.ToArray(),
        head.ToArray(),
        rows.ToMatrix()
      );
    }
    public static Mu::Table<T> MapToTable<T>(this List<(T, T)> entries, Func<(T, T), List<T>> conv, (string, string) head) {
      return Mu::Table<T>.Build(
        head.ToList(),
        entries.Map(conv)
      );
    }
    public static Mu::Table<T> MapToTable<T>(this List<(T, T, T)> entries, Func<(T, T, T), List<T>> conv, (string, string, string) head) {
      return Mu::Table<T>.Build(
        head.ToList(),
        entries.Map(conv)
      );
    }
    public static Mu::Table<T> ToTable<T>(this List<(T, T)> entries, (string, string) head) {
      return entries.MapToTable(Tup.ToList, head);
    }
    public static Mu::Table<T> ToTable<T>(this List<(T, T, T)> entries, (string, string, string) head) {
      return entries.MapToTable(Tup.ToList, head);
    }
  }
}
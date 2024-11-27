using System;
using System.Collections.Generic;

namespace Analys.VSTO.Types {
  public static class FieldTypeUtil {
    public static FieldType GetFieldType<T>(this T value) {
      switch (value) {
        case string phrase: return double.TryParse(phrase, out _) ? FieldType.Number : FieldType.String;
        case double number: return FieldType.Number;
        case int erroneous: return FieldType.Error;
        case DateTime date: return FieldType.Date;
        default:            return FieldType.Null;
      }
    }

    public static bool Has<T>(this ISet<T> set, T value) {
      return set.Contains(value);
    }

    public static FieldType PreferredType(this ISet<FieldType> set) {
      if (set.Has(FieldType.Number)) return FieldType.Number;
      if (set.Has(FieldType.Date)) return FieldType.Date;
      if (set.Has(FieldType.String)) return FieldType.String;
      if (set.Has(FieldType.Error)) return FieldType.Error;
      if (set.Has(FieldType.Null)) return FieldType.Null;
      return FieldType.Null;
    }

    public static FieldType SuggestedType(this ISet<FieldType> set) {
      if (set.Has(FieldType.Number) && !(set.Has(FieldType.Date) || set.Has(FieldType.String))) return FieldType.Number;
      if (set.Has(FieldType.Date) && !(set.Has(FieldType.String) || set.Has(FieldType.Number))) return FieldType.Date;
      if (set.Has(FieldType.String) && !(set.Has(FieldType.Number) || set.Has(FieldType.Date))) return FieldType.String;
      if (set.Has(FieldType.Error)) return FieldType.Error;
      if (set.Has(FieldType.Null)) return FieldType.Null;
      return FieldType.Null;
    }

    public static (FieldType, FieldStatus) FieldInfo(this ISet<FieldType> set) {
      FieldType suggestedType = set.SuggestedType(), preferredType = set.PreferredType();
      switch (suggestedType) {
        case FieldType.String:
        case FieldType.Number:
        case FieldType.Date:
          return (suggestedType, FieldStatus.Suggested);
        default:
          return (preferredType, FieldStatus.Preferred);
      }
    }

    public static string ParseToString<T>(this T value) {
      switch (value) {
        case string phrase: return phrase;
        case double number: return $"{number}";
        case int erroneous: return null;
        case DateTime date: return date.ToString("yyyy-MM-dd");
        default:            return value?.ToString();
      }
    }

    public static double ParseToNumber<T>(this T value) {
      switch (value) {
        case string phrase:  return double.TryParse(phrase, out var number) ? number : double.NaN;
        case double numeric: return numeric;
        default:             return double.NaN;
      }
    }

    public static DateTime? ParseToDate<T>(this T value) {
      switch (value) {
        case DateTime date: return date;
        case string phrase: return null;
        case double number: return null;
        case int erroneous: return null;
        default:            return null;
      }
    }
  }
}
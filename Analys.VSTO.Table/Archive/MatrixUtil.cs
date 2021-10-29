// using System;
// using System.Collections.Generic;
// using Veho.Matrix;
//
// namespace Analys.VSTO.Table {
//   public static class MatrixUtil {
//     public static IEnumerable<(T[] columns, FieldType type)> TypeInferredZeroizeIntoColumns<T>(this T[,] oneBased) {
//       var (height, width) = oneBased.Size();
//       var set = new HashSet<FieldType>(4);
//       T value;
//       for (int j = 0, jS = 1; j < width; j++, jS++) {
//         var column = new T[height];
//         for (var i = 0; i < height;) {
//           column[i] = value = oneBased[++i, jS];
//           set.Add(value.GetFieldType());
//         }
//         yield return (column, set.PreferredType());
//         set.Clear();
//       }
//     }
//     public static (T[] column, FieldType type) ZeroizeColumnWithPreferredType<T>(this T[,] oneBased, int y, int height = -1) {
//       if (height <= 0) height = oneBased.Height();
//       var types = new HashSet<FieldType>(4);
//       var column = oneBased.ZeroizeColumn(y, value => {
//         types.Add(value.GetFieldType());
//         return value;
//       }, height);
//       var fieldType = types.PreferredType();
//       return (column, fieldType);
//     }
//
//     public static (dynamic column, FieldType type, bool raw) TypeInferredZeroizeColumn<T>(this T[,] oneBased, int y, int height = -1) {
//       if (height <= 0) height = oneBased.Height();
//       var set = new HashSet<FieldType>(4);
//       var column = oneBased.ZeroizeColumn(y, value => {
//         set.Add(value.GetFieldType());
//         return value;
//       }, height);
//       var preferredType = set.PreferredType();
//       var narrowedType = set.SuggestedType();
//       switch (narrowedType) {
//         case FieldType.String: return (column.Map(FieldTypeUtil.ParseToString), narrowedType, false);
//         case FieldType.Number: return (column.Map(FieldTypeUtil.ParseToNumber), narrowedType, false);
//         case FieldType.Date:   return (column.Map(FieldTypeUtil.ParseToDate), narrowedType, false);
//         default:               return (column, preferredType, true);
//       }
//     }
//
//     public static double[] NumericColumn<T>(this T[,] oneBased, int y) {
//       var column = oneBased.ZeroizeColumn(y, FieldTypeUtil.ParseToNumber);
//       return column;
//     }
//
//
//     public static string[] StringColumn<T>(this T[,] oneBased, int y) {
//       var column = oneBased.ZeroizeColumn(y, FieldTypeUtil.ParseToString);
//       return column;
//     }
//
//     public static dynamic[] DynamicColumn<T>(this T[,] oneBased, int y) {
//       var column = oneBased.ZeroizeColumn(y, value => {
//         switch (value) {
//           case string phrase: return phrase;
//           case double number: return $"{number}";
//           case int erroneous: return null;
//           case DateTime date: return date.ToString("yyyy-MM-dd");
//           default:            return value?.ToString();
//         }
//       });
//       return column;
//     }
//   }
// }
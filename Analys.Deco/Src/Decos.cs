using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting.Enums;
using Typen;
using Veho.Matrix;
using Veho.Matrix.Rows;
using Veho.Types;
using Veho.Vector;

namespace Analys {
  public static class Decos {
    public static string Deco<T>(
      this T[,] matrix,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Rowwise,
      (Preset, Preset)? presets = null,
      params Effect[] effects
    ) {
      if (!matrix.Any()) return "[]";
      var t = new string(' ', tab * 2);
      var body = matrix.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) body = body.Fluo(orient, presets.Value, effects);
      return body
        .Padder(hasAnsi)
        .MapRows(row => t + row.Join())
        .Join(",\n");
    }
    public static string Deco<T>(
      this Table<T> table,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Columnwise,
      (Preset str, Preset num)? presets = null,
      params Effect[] effects
    ) {
      if (!table.Rows.Any()) return "[]";
      // var t = new string(' ', tab * 2);
      var body = table.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        body.Head = body.Head.Fluo(presets.Value, effects);
        body.Rows = body.Rows.Fluo(orient, presets.Value, effects);
      }
      var (head, rows) = (body.Head, body.Rows).Padder(hasAnsi);
      return head.Join(" | ") + Chars.LF +
             head.Map(x => new string('-', x.Length)).Join(" | ") + Chars.LF +
             rows.MapRows(row => row.Join(" | ")).Join(Chars.LF);
    }
  }
}
using System.Linq;
using Palett.Fluos;
using Palett.Types;
using Spare.Padder;
using Texting.Lange;
using Typen;
using Veho.Matrix;
using Veho.Matrix.Rows;
using Veho.Types;
using Veho.Vector;
using static Texting.Enums.Chars;

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
      var t = new string(' ', tab * 2);
      var body = table.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        body.Head = body.Head.Fluo(presets.Value, effects);
        body.Rows = body.Rows.Fluo(orient, presets.Value, effects);
      }
      var (head, line, rows) = (body.Head, body.Rows).Padder(hasAnsi);
      var lines = new[] {
        head.Join(" | "),
        line.Join(" + ")
      }.Concat(
        rows.MapRows(row => row.Join(" | "))
      ).ToArray();
      return lines.Map(x => t + x).Join(LF);
    }
    
    public static string Deco<T>(
      this Crostab<T> crostab,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Columnwise,
      (Preset str, Preset num)? presets = null,
      params Effect[] effects
    ) {
      if (!crostab.Rows.Any()) return "[]";
      var t = new string(' ', tab * 2);
      var body = crostab.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        body.Head = body.Head.Fluo(presets.Value, effects);
        body.Rows = body.Rows.Fluo(orient, presets.Value, effects);
      }
      var (title, hr, side) = (body.Title, body.Side).Padder(hasAnsi);
      var (head, line, rows) = (body.Head, body.Rows).Padder(hasAnsi);
      var lines = new[] {
        head.Join(" | "),
        line.Join(" + ")
      }.Concat(
        rows.MapRows(row => row.Join(" | "))
      ).ToArray();
      return lines.Map(x => t + x).Join(LF);
    }
  }
}
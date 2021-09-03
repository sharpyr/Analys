using Palett.Fluos;
using Palett.Types;
using Texting.Enums;
using Texting.Joiner;
using Typen;
using Veho;
using Veho.Matrix;
using Veho.Rows;
using Veho.Types;
using Veho.Vector;

namespace Analys {
  public static class Decos {
    // public static string Deco<T>(
    //   this T[,] matrix,
    //   byte tab = 1,
    //   bool hasAnsi = false,
    //   Operated orient = Operated.Rowwise,
    //   (Preset, Preset)? presets = null,
    //   params Effect[] effects
    // ) {
    //   if (!matrix.Any()) return "[]";
    //   var t = new string(' ', tab * 2);
    //   var body = matrix.Map(Conv.ToStr);
    //   if (presets.HasValue && (hasAnsi = true)) body = body.Fluo(orient, presets.Value, effects);
    //   return body
    //          .Padder(hasAnsi)
    //          .MapRows(row => t + row.Join(Strings.COSP))
    //          .Join(Strings.COLF);
    // }
    public static string Deco<T>(
      this Table<T> table,
      byte tab = 1,
      bool hasAnsi = false,
      Operated orient = Operated.Columnwise,
      (Preset str, Preset num)? presets = null,
      params Effect[] effects
    ) {
      if (!table.Rows.Any()) return "[]";
      var body = table.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        body.Head = body.Head.Fluo(presets.Value, effects);
        body.Rows = body.Rows.Fluo(orient, presets.Value, effects);
      }
      var (head, line, rows) = (body.Head, body.Rows).Padder(hasAnsi);
      var lines = Vec.From(
        head.Join(" | "),
        line.Join(" + ")
      ).Acquire(
        rows.MapRows(row => row.Join(" | "))
      );
      return lines.ContingentLines(Strings.LF, tab);
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
      var body = crostab.Map(Conv.ToStr);
      if (presets.HasValue && (hasAnsi = true)) {
        body.Side = body.Side.Fluo(presets.Value, effects);
        body.Head = body.Head.Fluo(presets.Value, effects);
        body.Rows = body.Rows.Fluo(orient, presets.Value, effects);
      }
      var (title, hr, side) = (body.Title, body.Side).Padder(hasAnsi);
      var (head, line, rows) = (body.Head, body.Rows).Padder(hasAnsi);
      var lines = Vec.From(
        title + " | " + head.Join(" | "),
        hr + " + " + line.Join(" + ")
      ).Acquire(
        side.Zip(
          rows.MapRows(row => row.Join(" | ")),
          (s, r) => s + " | " + r
        )
      );
      return lines.ContingentLines(Strings.LF, tab);
    }
  }
}
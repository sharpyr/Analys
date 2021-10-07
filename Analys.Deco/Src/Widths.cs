using System;
using Texting;
using Veho.Columns;
using Veho.Vector;
using Veho.Matrix;

namespace Analys {
  public static class WidthGetters {
    public static int WidthBy(this string[] vec, Func<string, int> lange) => vec
      .Fold((max, tx) => Math.Max(max, lange(tx)), 0);
    public static int[] WidthsBy(this string[,] mat, Func<string, int> lange) => mat.MapColumns(
      col => col.Fold((max, tx) => Math.Max(max, lange(tx)), 0)
    );
  }

  public static class Padders {
    public static (string head, string line, string[] rows) Padder(this (string title, string[] side) titleAndSide, bool ansi) {
      var (title, side) = titleAndSide;
      var (lange, padder) = (Langes.ToLange(ansi), PadFactory.ToPad(' ', ansi));
      var width = Math.Max(side.WidthBy(lange), lange(title));
      return (
        padder(title, width),
        new string('-', width),
        side.Map(v => padder(v, width))
      );
    }
    public static (string[] head, string[] line, string[,] rows) Padder(this (string[] head, string[,] rows) headAndRows, bool ansi) {
      var (head, rows) = headAndRows;
      var (lange, padder) = (Langes.ToLange(ansi), PadFactory.ToPad(' ', ansi));
      var widths = head.Zip(rows.WidthsBy(lange), (tx, wd) => Math.Max(lange(tx), wd));
      return (
        head.Map((j, v) => padder(v, widths[j])),
        widths.Map(width => new string('-', width)),
        rows.Map((i, j, v) => padder(v, widths[j]))
      );
    }
  }
}
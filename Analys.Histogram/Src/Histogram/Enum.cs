using System;

namespace Analys.Histogram {
  [Flags]
  public enum Open {
    None = 0b00,
    Min = 0b01,
    Max = 0b10,
  }

  public static class EnumUtil {
    public static (bool min, bool max) Decode(this Open open) => (((byte)open >> 0 & 0b1) == 0b1, ((byte)open >> 1 & 0b1) == 0b1);
  }
}
using static System.Double;

namespace Analys.Stat {
  public interface IStat {
    double Value { get; }
    IStat Record(double num);
  }

  public static class StatExt {
    public static IStat Record(IStat target, double value) => IsNaN(value) ? target : target.Record(value);
  }
}
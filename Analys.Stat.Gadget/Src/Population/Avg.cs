namespace Analys.Stat.Gadget.Population {
  public struct Avg : IStat {
    public double Sum { get; set; }
    public int Count { get; set; }
    public double Value => Count == 0 ? 0 : Sum / Count;
    public IStat Record(double num) {
      Sum += num;
      Count += 1;
      return this;
    }
    public static IStat Build() => new Avg { Sum = 0, Count = 0 };
  }
}
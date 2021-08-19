namespace Analys.Types {
  public struct Avg {
    public double Sum { get; set; }
    public int Count { get; set; }
    public double Value => Count == 0 ? 0 : Sum / Count;

    public Avg Record(double num) {
      this.Sum += num;
      this.Count += 1;
      return this;
    }
    public static Avg Build() => new Avg { Sum = 0, Count = 0 };
  }
}
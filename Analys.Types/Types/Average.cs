namespace Analys.Types {
  public struct Average {
    public double Sum { get; set; }
    public int Count { get; set; }
    public double Value => Count == 0 ? 0 : Sum / Count;

    public Average Take(double num) {
      this.Sum += num;
      this.Count += 1;
      return this;
    }
    public static Average Build() => new Average {Sum = 0, Count = 0};
  }
}
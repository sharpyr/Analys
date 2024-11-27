using Veho;

namespace Analys {
  public partial class Crostab<T> {
    public static Crostab<T> operator +(Crostab<T> a, Crostab<T> b) => Build(a.Side, a.Head, LinearSpace<T>.op_Addition(a.Rows, b.Rows));
    public static Crostab<T> operator -(Crostab<T> a, Crostab<T> b) => Build(a.Side, a.Head, LinearSpace<T>.op_Subtraction(a.Rows, b.Rows));
    public static Crostab<T> operator *(Crostab<T> a, Crostab<T> b) => Build(a.Side, a.Head, LinearSpace<T>.op_Multiply(a.Rows, b.Rows));
    public static Crostab<T> operator /(Crostab<T> a, Crostab<T> b) => Build(a.Side, a.Head, LinearSpace<T>.op_Division(a.Rows, b.Rows));
    public static Crostab<T> operator ^(Crostab<T> a, Crostab<T> b) => Build(a.Side, a.Head, LinearSpace<T>.op_Concatenate(a.Rows, b.Rows));

    public static Crostab<T> operator +(Crostab<T> a, T b) => Build(a.Side, a.Head, LinearSpace<T>.op_Addition(a.Rows, b));
    public static Crostab<T> operator -(Crostab<T> a, T b) => Build(a.Side, a.Head, LinearSpace<T>.op_Subtraction(a.Rows, b));
    public static Crostab<T> operator *(Crostab<T> a, T b) => Build(a.Side, a.Head, LinearSpace<T>.op_Multiply(a.Rows, b));
    public static Crostab<T> operator /(Crostab<T> a, T b) => Build(a.Side, a.Head, LinearSpace<T>.op_Division(a.Rows, b));
    public static Crostab<T> operator ^(Crostab<T> a, T b) => Build(a.Side, a.Head, LinearSpace<T>.op_Concatenate(a.Rows, b));

    // public static Crostab<T> operator +(T a, Crostab<T> b) => Crostab<T>.Build(b.Side, b.Head, LinearSpace.Add(a.Rows, b));
    // public static Crostab<T> operator -(T a, Crostab<T> b) => Crostab<T>.Build(b.Side, b.Head, LinearSpace.Subtract(a.Rows, b));
    // public static Crostab<T> operator *(T a, Crostab<T> b) => Crostab<T>.Build(b.Side, b.Head, LinearSpace.Multiply(a.Rows, b));
    // public static Crostab<T> operator /(T a, Crostab<T> b) => Crostab<T>.Build(b.Side, b.Head, LinearSpace.DivideBy(a.Rows, b));

    // public static Crostab<T> Add(Crostab<T> a, Crostab<T> b) => a + b;
    // public static Crostab<T> Subtract(Crostab<T> a, Crostab<T> b) => a - b;
    // public static Crostab<T> Multiply(Crostab<T> a, Crostab<T> b) => a * b;
    // public static Crostab<T> Divide(Crostab<T> a, Crostab<T> b) => a / b;
    // public static Crostab<T> Add(Crostab<T> a, T b) => a + b;
    // public static Crostab<T> Subtract(Crostab<T> a, T b) => a - b;
    // public static Crostab<T> Multiply(Crostab<T> a, T b) => a * b;
    // public static Crostab<T> Divide(Crostab<T> a, T b) => a / b;
  }
}
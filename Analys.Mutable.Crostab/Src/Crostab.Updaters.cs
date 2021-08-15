// namespace Analys.Mutable {
//   public partial class Crostab<T> {
//     public Crostab<T> WriteRow(string label, List<List<T>> vec) {
//       var x = this.RoIn(label);
//       this.Rows.WriteRow(vec, x);
//       return this;
//     }
//     public Crostab<T> AddRow(string label, List<List<T>> vec) {
//       this.Side = this.Side.Add(label);
//       this.Rows = this.Rows.AddRow(vec);
//       return this;
//     }
//     public Crostab<T> UnshiftRow(string label, List<List<T>> vec) {
//       this.Side = this.Side.Unshift(label);
//       this.Rows = this.Rows.UnshiftRow(vec);
//       return this;
//     }
//     public Crostab<T> WriteColumn(string label, List<List<T>> vec) {
//       var j = this.CoIn(label);
//       this.Rows.WriteColumn(vec, j);
//       return this;
//     }
//     public Crostab<T> AddColumn(string label, List<List<T>> vec) {
//       this.Head = this.Head.Add(label);
//       this.Rows = this.Rows.AddColumn(vec);
//       return this;
//     }
//     public Crostab<T> UnshiftColumn(string label, List<List<T>> vec) {
//       this.Head = this.Head.Unshift(label);
//       this.Rows = this.Rows.UnshiftColumn(vec);
//       return this;
//     }
//   }
// }
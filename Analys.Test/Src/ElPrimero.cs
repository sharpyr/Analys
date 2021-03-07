// using System;
// using System.Collections.Generic;
// using NUnit.Framework;
// using Palett.Presets;
// using Typen.Numeral;
// using Veho.Dictionary;
// using Veho.Types;
//
// namespace Analys.Test {
//
//
//   [TestFixture]
//   public class ElPrimeroTest {
//     [Test]
//     public void TestFunc() {
//       var candidates = new Dictionary<string, string> {
//         {"alpha", "5"},
//         {"beta", "-"},
//         {"gamma", ""},
//       };
//       var (elapsed, result) = ElPrimero.Strategies(
//         (int) 1E+6,
//         Dict.From(
//           ("CastDouble", (Func<string, double>) Num.CastDouble),
//           ("CastDouble2", (Func<string, double>) Num.CastDouble)
//         ),
//         candidates
//       );
//       elapsed.Deco(orient: Operated.Rowwise, presets: (PresetCollection.Subtle, PresetCollection.Fresh)).Logger();
//       result.Deco().Logger();
//       // ElPrimero.Profile("some", (int) 1E+6, () => "5".CastDouble());
//     }
//   }
// }
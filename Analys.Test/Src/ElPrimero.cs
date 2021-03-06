using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using Veho.Enumerable;
using Veho.Matrix;
using Veho.Vector;

namespace Analys.Test {
  public static class ElPrimero {
    public static Table<double> Strategies(
      int iteration,
      Dictionary<string, Action> methods
    ) {
      var table = DataFactory.Init(methods);
      var eta = new Stopwatch();
      foreach (var m in methods)
        try { table[0, m.Key] = eta.Profile(iteration, m.Key, m.Value); }
        catch (Exception e) { table[0, m.Key] = double.NaN; }
      return table;
    }
    public static (Crostab<double> elapsed, Crostab<TO> result) Strategies<T, TO>(
      int iteration,
      Dictionary<string, Func<T, TO>> methods,
      Dictionary<string, T> parameters
    ) {
      var (elapsed, result) = DataFactory.Init(methods, parameters);
      var eta = new Stopwatch();
      foreach (var m in methods)
        foreach (var p in parameters)
          try { (elapsed[p.Key, m.Key], result[p.Key, m.Key]) = eta.Profile(iteration, m, p); }
          catch (Exception e) { elapsed[p.Key, m.Key] = double.NaN; }
      return (elapsed, result);
    }
  }

  public static class DataFactory {
    public static (Crostab<double> elapsed, Crostab<TO> result) Init<T, TO>(
      Dictionary<string, Func<T, TO>> methods,
      Dictionary<string, T> parameters
    ) {
      string[] m = methods.Keys.ToArray(), p = parameters.Keys.ToArray();
      return (Crostab<double>.Build(p, m), Crostab<TO>.Build(p, m));
    }
    public static Table<double> Init(Dictionary<string, Action> methods) => Table<double>.Build(
      methods.Keys.ToArray(),
      Vec.Iso<double>(methods.Count, 0).ToRow()
    );
  }

  public static class Profilers {
    public static (double elapsed, TO result) Profile<T, TO>(
      this Stopwatch eta,
      int iterations,
      KeyValuePair<string, Func<T, TO>> method,
      KeyValuePair<string, T> parameter
    ) {
      var v = parameter.Value;
      var f = method.Value;
      //Run at highest priority to minimize fluctuations caused by other processes/threads
      Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
      Thread.CurrentThread.Priority = ThreadPriority.Highest;
      // warm up 
      var result = f(v);
      // clean up
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      eta.Restart();
      for (var i = 0; i < iterations; i++) f(v);
      eta.Stop();
      var elapsed = eta.Elapsed.TotalMilliseconds;
      Console.WriteLine($"Elapsed {elapsed} ms: {method.Key}( {parameter.Key} )");
      return (elapsed, result);
    }

    public static double Profile(
      this Stopwatch eta,
      int iterations,
      string label,
      Action method
    ) {
      //Run at highest priority to minimize fluctuations caused by other processes/threads
      Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
      Thread.CurrentThread.Priority = ThreadPriority.Highest;
      // warm up 
      method();
      // clean up
      GC.Collect();
      GC.WaitForPendingFinalizers();
      GC.Collect();
      eta.Restart();
      for (var i = 0; i < iterations; i++) method();
      eta.Stop();
      var elapsed = eta.Elapsed.TotalMilliseconds;
      Console.WriteLine($"Elapsed {elapsed} ms: {label}()");
      return elapsed;
    }
  }

  [TestFixture]
  public class ElPrimeroTest {
    [Test]
    public void TestFunc() {
      var x = (object) "5";
      // ElPrimero.Profile("some", (int) 1E+6, () => x.CastDouble());
    }
  }
}
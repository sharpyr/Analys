using System;
using System.Reflection;
using System.Text;
using NUnit.Framework;

namespace Analys.Test {
  public static class JonSkeetLib {
    public static Func<T, object, object> MagicMethod<T>(MethodInfo method) where T : class {
      // First fetch the generic form
      var m = typeof(JonSkeetLib).GetMethod("MagicMethodHelper",
        BindingFlags.Static | BindingFlags.Public);
      // Now supply the type arguments
      var constructedHelper = m.MakeGenericMethod(typeof(T), method.GetParameters()[0].ParameterType, method.ReturnType);
      // Now call it. The null argument is because it's a static method.
      var ret = constructedHelper.Invoke(null, new object[] {method});
      // Cast the result to the right kind of delegate and return it
      return (Func<T, object, object>) ret;
    }

    public static Func<TTarget, object, object> MagicMethodHelper<TTarget, TParam, TReturn>(this MethodInfo method)
      where TTarget : class {
      // Convert the slow MethodInfo into a fast, strongly typed, open delegate
      var func = (Func<TTarget, TParam, TReturn>) Delegate.CreateDelegate(typeof(Func<TTarget, TParam, TReturn>), method);
      // Now create a more weakly typed delegate which will call the strongly typed one
      return (TTarget target, object param) => func(target, (TParam) param);
    }
  }

  [TestFixture]
  public class MethodInfoTests {
    [Test]
    public void TestFunc() {
      var indexOf = typeof(string).GetMethod("IndexOf", new Type[] {typeof(char)});
      var getByteCount = typeof(Encoding).GetMethod("GetByteCount", new Type[] {typeof(string)});

      Func<string, object, object> indexOfFunc = JonSkeetLib.MagicMethod<string>(indexOf);
      Func<Encoding, object, object> getByteCountFunc = JonSkeetLib.MagicMethod<Encoding>(getByteCount);
      
      Console.WriteLine(indexOfFunc("Hello", 'e'));
      Console.WriteLine(getByteCountFunc(Encoding.UTF8, "Euro sign:\u20ac"));
    }
  }
}
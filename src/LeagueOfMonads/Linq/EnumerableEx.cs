using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfMonads.Linq
{
   public static class EnumerableEx
   {
      [DebuggerNonUserCode]
      public static void EvaluateAndIgnore<T>(this IEnumerable<T> e)
      {
         // ReSharper disable once ReturnValueOfPureMethodIsNotUsed
         e.ToList();
      }

      [DebuggerNonUserCode]
      public static string Join<T>(this IEnumerable<T> t, string delimiter = null)
      {
         return string.Join(delimiter, t);
      }

      [DebuggerNonUserCode]
      public static IEnumerable<T> WaitAll<T>(this IEnumerable<Task<T>> tasks)
      {
         var a = tasks.ToArray();

         // ReSharper disable once CoVariantArrayConversion
         Task.WaitAll(a);

         return a
            .Select(t => t.Result)
            .ToList();
      }

      [DebuggerNonUserCode]
      public static IEnumerable<Task> WaitAll(this IEnumerable<Task> tasks)
      {
         var a = tasks.ToArray();
         
         Task.WaitAll(a);

         return a;
      }
   }
}

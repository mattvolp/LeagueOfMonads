using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueOfMonads.Linq
{
   public static class EnumerableEx
   {
      public static string Join<T>(this IEnumerable<T> t, string delimiter = null)
      {
         return string.Join(delimiter, t);
      }

      public static IEnumerable<T> WaitAll<T>(this IEnumerable<Task<T>> tasks)
      {
         var a = tasks.ToArray();

         // ReSharper disable once CoVariantArrayConversion
         Task.WaitAll(a);

         return a
            .Select(t => t.Result)
            .ToList();
      }
   }
}

using System.Collections.Generic;

namespace LeagueOfMonads.Linq
{
   public static class ExceptEx
   {
      public static IEnumerable<T> ExceptAll<T>(this IEnumerable<T> first, IEnumerable<T> second)
      {
         var hashset = new HashSet<T>(second);
         foreach (var f in first)
            if (!hashset.Contains(f))
               yield return f;
      }

      public static IEnumerable<T> ExceptAll<T>(this IEnumerable<T> first, IEnumerable<T> second, IEqualityComparer<T> comparer)
      {
         var hashset = new HashSet<T>(second, comparer);
         foreach (var f in first)
            if (!hashset.Contains(f))
               yield return f;
      }
   }
}
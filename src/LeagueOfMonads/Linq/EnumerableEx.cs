using System.Collections.Generic;

namespace LeagueOfMonads.Linq
{
   public static class EnumerableEx
   {
      public static string Join<T>(this IEnumerable<T> t, string delimiter = null)
      {
         return string.Join(delimiter, t);
      }
   }
}

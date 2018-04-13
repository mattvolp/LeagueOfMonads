using System;
using System.Collections.Generic;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.Linq
{
   public static class DistinctExt
   {
      public static IEnumerable<T> DistinctBy<T, A>(this IEnumerable<T> source, Func<T, A> selector)
         where A : struct
      {
         var uniques = new HashSet<A>();

         foreach (var item in source)
            if (uniques.Add(selector(item)))
               yield return item;
      }
   }
}
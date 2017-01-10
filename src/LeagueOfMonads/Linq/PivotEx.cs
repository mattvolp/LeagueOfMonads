using System;
using System.Collections.Generic;

namespace LeagueOfMonads.Linq
{
   public static class PivotEx
   {
      public static IEnumerable<TResult> Pivot<T, TResult>(this IEnumerable<T> items, Func<T, T, TResult> selector)
      {
         var i = 1;
         var b = false;
         var p = default(T);

         foreach (var item in items)
         {
            if (i++ % 2 == 0)
            {
               yield return selector(p, item);
               b = false;
            }
            else
            {
               p = item;
               b = true;
            }
         }

         if (b) yield return selector(p, default(T));
      }

      public static IEnumerable<TResult> Pivot3<T, TResult>(this IEnumerable<T> items, Func<T, T, T, TResult> selector)
      {
         var i = 1;
         var c = 0;
         var p1 = default(T);
         var p2 = default(T);

         foreach (var item in items)
         {
            if (i++ % 3 == 0)
            {
               yield return selector(p1, p2, item);
               c = 0;
               p1 = p2 = default(T);
            }
            else
            {
               c++;
               p1 = p2;
               p2 = item;
            }
         }

         if (c == 1)
            yield return selector(p2, default(T), default(T));
         else if (c == 2)
            yield return selector(p1, p2, default(T));
      }
   }
}

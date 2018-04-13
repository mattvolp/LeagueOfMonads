using System;
using System.Collections.Generic;

namespace LeagueOfMonads.Linq
{
   public static class DeselectExt
   {
      public static IEnumerable<TResult> Deselect<T1, T2, TResult>(this IEnumerable<Tuple<T1, T2>> tuples, Func<T1, T2, TResult> selector)
      {
         foreach (var tuple in tuples)
            yield return selector(tuple.Item1, tuple.Item2);
      }

      public static IEnumerable<TResult> Deselect<T1, T2, T3, TResult>(this IEnumerable<Tuple<T1, T2, T3>> tuples, Func<T1, T2, T3, TResult> selector)
      {
         foreach (var tuple in tuples)
            yield return selector(tuple.Item1, tuple.Item2, tuple.Item3);
      }

      public static IEnumerable<TResult> Deselect<T1, T2, T3, T4, TResult>(this IEnumerable<Tuple<T1, T2, T3, T4>> tuples, Func<T1, T2, T3, T4, TResult> selector)
      {
         foreach (var tuple in tuples)
            yield return selector(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4);
      }

      public static IEnumerable<TResult> Deselect<T1, T2, T3, T4, T5, TResult>(this IEnumerable<Tuple<T1, T2, T3, T4, T5>> tuples, Func<T1, T2, T3, T4, T5, TResult> selector)
      {
         foreach (var tuple in tuples)
            yield return selector(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5);
      }

      public static IEnumerable<TResult> Deselect<T1, T2, T3, T4, T5, T6, TResult>(this IEnumerable<Tuple<T1, T2, T3, T4, T5, T6>> tuples, Func<T1, T2, T3, T4, T5, T6, TResult> selector)
      {
         foreach (var tuple in tuples)
            yield return selector(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6);
      }

      public static IEnumerable<TResult> Deselect<T1, T2, T3, T4, T5, T6, T7, TResult>(this IEnumerable<Tuple<T1, T2, T3, T4, T5, T6, T7>> tuples, Func<T1, T2, T3, T4, T5, T6, T7, TResult> selector)
      {
         foreach (var tuple in tuples)
            yield return selector(tuple.Item1, tuple.Item2, tuple.Item3, tuple.Item4, tuple.Item5, tuple.Item6, tuple.Item7);
      }
   }
}
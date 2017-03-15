using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.Linq
{
   public static class SelectEx
   {
      public static IEnumerable<O> Select<T, A, O>(this IEnumerable<T> e, Func<T, A, O> f, A a)
      {
         return e.Select(t => f(t, a));
      }


      public static IEnumerable<O> Select<T, A, B, O>(this IEnumerable<T> e, Func<T, A, B, O> f, A a, B b)
      {
         return e.Select(t => f(t, a, b));
      }


      public static IEnumerable<O> Select<T, A, B, C, O>(this IEnumerable<T> e, Func<T, A, B, C, O> f, A a, B b, C c)
      {
         return e.Select(t => f(t, a, b, c));
      }
   }
}
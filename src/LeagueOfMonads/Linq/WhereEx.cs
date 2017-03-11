using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.Linq
{
   public static class WhereEx
   {
      [DebuggerNonUserCode]
      public static IEnumerable<T> Where<T, A>(this IEnumerable<T> e, Func<T, A, bool> f, A a)
      {
         return e.Where(t => f(t, a));
      }

      [DebuggerNonUserCode]
      public static IEnumerable<T> Where<T, A, B>(this IEnumerable<T> e, Func<T, A, B, bool> f, A a, B b)
      {
         return e.Where(t => f(t, a, b));
      }

      [DebuggerNonUserCode]
      public static IEnumerable<T> Where<T, A, B, C>(this IEnumerable<T> e, Func<T, A, B, C, bool> f, A a, B b, C c)
      {
         return e.Where(t => f(t, a, b, c));
      }
   }
}

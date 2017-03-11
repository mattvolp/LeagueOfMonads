﻿using System;
using System.Collections.Generic;
using System.Diagnostics;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.Linq
{
   public static class IterateEx
   {
      [DebuggerNonUserCode]
      public static IEnumerable<T> Iterate<T>(this IEnumerable<T> e, Action<T> action)
      {
         foreach (var t in e)
         {
            action(t);
            yield return t;
         } 
      }

      [DebuggerNonUserCode]
      public static IEnumerable<T> Iterate<T, A>(this IEnumerable<T> e, Action<T, A> action, A a)
      {
         return Iterate(e, t => action(t, a));
      }

      [DebuggerNonUserCode]
      public static IEnumerable<T> Iterate<T, A, B>(this IEnumerable<T> e, Action<T, A, B> action, A a, B b)
      {
         return Iterate(e, t => action(t, a, b));
      }

      [DebuggerNonUserCode]
      public static IEnumerable<T> Iterate<T, A, B, C>(this IEnumerable<T> e, Action<T, A, B, C> action, A a, B b, C c)
      {
         return Iterate(e, t => action(t, a, b, c));         
      }      
   }
}

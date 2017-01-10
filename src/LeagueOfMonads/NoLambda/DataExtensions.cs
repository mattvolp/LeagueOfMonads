using System;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.NoLambda
{
   public static class DataExtensions
   {
      public static Data<TResult> Map<T, A, TResult>(this Data<T> d, Func<T, A, TResult> f, A a)
      {
         return new Data<TResult>(f(d.Value, a));
      }

      public static Data<TResult> Map<T, A, B, TResult>(this Data<T> d, Func<T, A, B, TResult> f, A a, B b)
      {
         return new Data<TResult>(f(d.Value, a, b));
      }

      public static Data<TResult> Map<T, A, B, C, TResult>(this Data<T> d, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return new Data<TResult>(f(d.Value, a, b, c));
      }
   }
}

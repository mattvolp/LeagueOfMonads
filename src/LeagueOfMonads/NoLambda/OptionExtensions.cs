using System;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.NoLambda
{
   public static class OptionExtensions
   {
      // MAP #1

      public static Option<TResult> Map<T, A, TResult>(this Option<T> m, Func<T, A, TResult> f, A a)
      {
         return m.Map(t => f(t, a));
      }

      public static Option<TResult> Map<T, A, B, TResult>(this Option<T> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return m.Map(t => f(t, a, b));
      }

      public static Option<TResult> Map<T, A, B, C, TResult>(this Option<T> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      // MAP #2

      public static Task<Option<TResult>> Map<T, A, TResult>(this Option<T> m, Func<T, A, Task<TResult>> f, A a)
      {
         return m.Map(t => f(t, a));         
      }

      public static Task<Option<TResult>> Map<T, A, B, TResult>(this Option<T> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return m.Map(t => f(t, a, b));
      }

      public static Task<Option<TResult>> Map<T, A, B, C, TResult>(this Option<T> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      // MAP EX #1

      public static async Task<Option<TResult>> Map<T, A, TResult>(this Task<Option<T>> m, Func<T, A, TResult> f, A a)
      {         
         return (await m).Map(t => f(t, a));
      }

      public static async Task<Option<TResult>> Map<T, A, B, TResult>(this Task<Option<T>> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return (await m).Map(t => f(t, a, b));
      }

      public static async Task<Option<TResult>> Map<T, A, B, C, TResult>(this Task<Option<T>> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return (await m).Map(t => f(t, a, b, c));
      }

      // MAP EX #2

      public static async Task<Option<TResult>> Map<T, A, TResult>(this Task<Option<T>> m, Func<T, A, Task<TResult>> f, A a)
      {
         return await (await m).Map(async t => await f(t, a));         
      }

      public static async Task<Option<TResult>> Map<T, A, B, TResult>(this Task<Option<T>> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return await (await m).Map(async t => await f(t, a, b));
      }

      public static async Task<Option<TResult>> Map<T, A, B, C, TResult>(this Task<Option<T>> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return await (await m).Map(async t => await f(t, a, b, c));
      }

      // TEE #1

      public static Option<T> Tee<T, A>(this Option<T> m, Action<T, A> f, A a)
      {
         return m.Tee(t => f(t, a));
      }

      public static Option<T> Tee<T, A, B>(this Option<T> m, Action<T, A, B> f, A a, B b)
      {
         return m.Tee(t => f(t, a, b));
      }

      public static Option<T> Tee<T, A, B, C>(this Option<T> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return m.Tee(t => f(t, a, b, c));                  
      }

      // TEE #2

      public static Task<Option<T>> Tea<T, A>(this Option<T> m, Func<T, A, Task> f, A a)
      {
         return m.Tea(t => f(t, a));
      }

      public static Task<Option<T>> Tea<T, A, B>(this Option<T> m, Func<T, A, B, Task> f, A a, B b)
      {
         return m.Tea(t => f(t, a, b));
      }

      public static Task<Option<T>> Tea<T, A, B, C>(this Option<T> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return m.Tea(t => f(t, a, b, c));
      }

      // TEE EX #1

      public static async Task<Option<T>> Tee<T, A>(this Task<Option<T>> m, Action<T, A> f, A a)
      {
         return (await m).Tee(t => f(t, a));
      }

      public static async Task<Option<T>> Tee<T, A, B>(this Task<Option<T>> m, Action<T, A, B> f, A a, B b)
      {
         return (await m).Tee(t => f(t, a, b));
      }

      public static async Task<Option<T>> Tee<T, A, B, C>(this Task<Option<T>> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return (await m).Tee(t => f(t, a, b, c));
      }

      // TEE EX #2

      public static async Task<Option<T>> Tea<T, A>(this Task<Option<T>> m, Func<T, A, Task> f, A a)
      {
         return await (await m).Tea(t => f(t, a));
      }

      public static async Task<Option<T>> Tea<T, A, B>(this Task<Option<T>> m, Func<T, A, B, Task> f, A a, B b)
      {
         return await (await m).Tea(t => f(t, a, b));
      }

      public static async Task<Option<T>> Tea<T, A, B, C>(this Task<Option<T>> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return await (await m).Tea(t => f(t, a, b, c));
      }
   }
}

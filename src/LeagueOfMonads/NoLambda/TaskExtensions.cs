using System;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.NoLambda
{
   public static class TaskExtensions
   {
      // MAP EX #1


      public static async Task<TResult> Map<T, A, TResult>(this Task<T> m, Func<T, A, TResult> f, A a)
      {
         return await m.Map(t => f(t, a));
      }


      public static async Task<TResult> Map<T, A, B, TResult>(this Task<T> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return await m.Map(t => f(t, a, b));
      }


      public static async Task<TResult> Map<T, A, B, C, TResult>(this Task<T> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return await m.Map(t => f(t, a, b, c));
      }

      // MAP EX #2


      public static async Task<TResult> Map<T, A, TResult>(this Task<T> m, Func<T, A, Task<TResult>> f, A a)
      {
         return await m.Map(async t => await f(t, a));
      }


      public static async Task<TResult> Map<T, A, B, TResult>(this Task<T> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return await m.Map(async t => await f(t, a, b));
      }


      public static async Task<TResult> Map<T, A, B, C, TResult>(this Task<T> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return await m.Map(async t => await f(t, a, b, c));
      }

      // TEE EX #1


      public static async Task<T> Tee<T, A>(this Task<T> m, Action<T, A> f, A a)
      {
         return await m.Tee(t => f(t, a));
      }


      public static async Task<T> Tee<T, A, B>(this Task<T> m, Action<T, A, B> f, A a, B b)
      {
         return await m.Tee(t => f(t, a, b));
      }


      public static async Task<T> Tee<T, A, B, C>(this Task<T> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return await m.Tee(t => f(t, a, b, c));
      }

      // TEE EX #2


      public static async Task<T> Tea<T, A>(this Task<T> m, Func<T, A, Task> f, A a)
      {
         return await m.Tee(t => f(t, a));
      }


      public static async Task<T> Tea<T, A, B>(this Task<T> m, Func<T, A, B, Task> f, A a, B b)
      {
         return await m.Tee(t => f(t, a, b));
      }


      public static async Task<T> Tea<T, A, B, C>(this Task<T> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return await m.Tee(t => f(t, a, b, c));
      }
   }
}
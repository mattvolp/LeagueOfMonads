using System;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.NoLambda
{
   public static class IdentityExt
   {
      // MAP #1


      public static Identity<TResult> Map<T, A, TResult>(this Identity<T> m, Func<T, A, TResult> f, A a)
      {
         return m.Map(t => f(t, a));
      }


      public static Identity<TResult> Map<T, A, B, TResult>(this Identity<T> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return m.Map(t => f(t, a, b));
      }


      public static Identity<TResult> Map<T, A, B, C, TResult>(this Identity<T> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      // MAP #2


      public static Task<Identity<TResult>> Map<T, A, TResult>(this Identity<T> m, Func<T, A, Task<TResult>> f, A a)
      {
         return m.Map(t => f(t, a));
      }


      public static Task<Identity<TResult>> Map<T, A, B, TResult>(this Identity<T> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return m.Map(t => f(t, a, b));
      }


      public static Task<Identity<TResult>> Map<T, A, B, C, TResult>(this Identity<T> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      // MAP EX #1


      public static async Task<Identity<TResult>> Map<T, A, TResult>(this Task<Identity<T>> m, Func<T, A, TResult> f, A a)
      {
         return (await m).Map(t => f(t, a));
      }


      public static async Task<Identity<TResult>> Map<T, A, B, TResult>(this Task<Identity<T>> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return (await m).Map(t => f(t, a, b));
      }


      public static async Task<Identity<TResult>> Map<T, A, B, C, TResult>(this Task<Identity<T>> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return (await m).Map(t => f(t, a, b, c));
      }

      // MAP EX #2


      public static async Task<Identity<TResult>> Map<T, A, TResult>(this Task<Identity<T>> m, Func<T, A, Task<TResult>> f, A a)
      {
         return await (await m).Map(async t => await f(t, a));
      }


      public static async Task<Identity<TResult>> Map<T, A, B, TResult>(this Task<Identity<T>> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return await (await m).Map(async t => await f(t, a, b));
      }


      public static async Task<Identity<TResult>> Map<T, A, B, C, TResult>(this Task<Identity<T>> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return await (await m).Map(async t => await f(t, a, b, c));
      }

      // TEE #1


      public static Identity<T> Tee<T, A>(this Identity<T> m, Action<T, A> f, A a)
      {
         return m.Tee(t => f(t, a));
      }


      public static Identity<T> Tee<T, A, B>(this Identity<T> m, Action<T, A, B> f, A a, B b)
      {
         return m.Tee(t => f(t, a, b));
      }


      public static Identity<T> Tee<T, A, B, C>(this Identity<T> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return m.Tee(t => f(t, a, b, c));
      }

      // TEE #2


      public static Task<Identity<T>> Tea<T, A>(this Identity<T> m, Func<T, A, Task> f, A a)
      {
         return m.Tea(t => f(t, a));
      }


      public static Task<Identity<T>> Tea<T, A, B>(this Identity<T> m, Func<T, A, B, Task> f, A a, B b)
      {
         return m.Tea(t => f(t, a, b));
      }


      public static Task<Identity<T>> Tea<T, A, B, C>(this Identity<T> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return m.Tea(t => f(t, a, b, c));
      }

      // TEE EX #1


      public static async Task<Identity<T>> Tee<T, A>(this Task<Identity<T>> m, Action<T, A> f, A a)
      {
         return (await m).Tee(t => f(t, a));
      }


      public static async Task<Identity<T>> Tee<T, A, B>(this Task<Identity<T>> m, Action<T, A, B> f, A a, B b)
      {
         return (await m).Tee(t => f(t, a, b));
      }


      public static async Task<Identity<T>> Tee<T, A, B, C>(this Task<Identity<T>> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return (await m).Tee(t => f(t, a, b, c));
      }

      // TEE EX #2


      public static async Task<Identity<T>> Tea<T, A>(this Task<Identity<T>> m, Func<T, A, Task> f, A a)
      {
         return await (await m).Tea(t => f(t, a));
      }


      public static async Task<Identity<T>> Tea<T, A, B>(this Task<Identity<T>> m, Func<T, A, B, Task> f, A a, B b)
      {
         return await (await m).Tea(t => f(t, a, b));
      }


      public static async Task<Identity<T>> Tea<T, A, B, C>(this Task<Identity<T>> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return await (await m).Tea(t => f(t, a, b, c));
      }
   }
}
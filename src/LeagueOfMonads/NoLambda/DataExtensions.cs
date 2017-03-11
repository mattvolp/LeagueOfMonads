using System;
using System.Diagnostics;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.NoLambda
{
   public static class DataExtensions
   {
      // MAP #1

      [DebuggerHidden]
      public static Data<TResult> Map<T, A, TResult>(this Data<T> m, Func<T, A, TResult> f, A a)
      {
         return m.Map(t => f(t, a));
      }

      [DebuggerHidden]
      public static Data<TResult> Map<T, A, B, TResult>(this Data<T> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return m.Map(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static Data<TResult> Map<T, A, B, C, TResult>(this Data<T> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      // MAP #2

      [DebuggerHidden]
      public static Task<Data<TResult>> Map<T, A, TResult>(this Data<T> m, Func<T, A, Task<TResult>> f, A a)
      {
         return m.Map(t => f(t, a));         
      }

      [DebuggerHidden]
      public static Task<Data<TResult>> Map<T, A, B, TResult>(this Data<T> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return m.Map(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static Task<Data<TResult>> Map<T, A, B, C, TResult>(this Data<T> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      // MAP EX #1

      [DebuggerHidden]
      public static async Task<Data<TResult>> Map<T, A, TResult>(this Task<Data<T>> m, Func<T, A, TResult> f, A a)
      {         
         return (await m).Map(t => f(t, a));
      }

      [DebuggerHidden]
      public static async Task<Data<TResult>> Map<T, A, B, TResult>(this Task<Data<T>> m, Func<T, A, B, TResult> f, A a, B b)
      {
         return (await m).Map(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static async Task<Data<TResult>> Map<T, A, B, C, TResult>(this Task<Data<T>> m, Func<T, A, B, C, TResult> f, A a, B b, C c)
      {
         return (await m).Map(t => f(t, a, b, c));
      }

      // MAP EX #2

      [DebuggerHidden]
      public static async Task<Data<TResult>> Map<T, A, TResult>(this Task<Data<T>> m, Func<T, A, Task<TResult>> f, A a)
      {
         return await (await m).Map(async t => await f(t, a));         
      }

      [DebuggerHidden]
      public static async Task<Data<TResult>> Map<T, A, B, TResult>(this Task<Data<T>> m, Func<T, A, B, Task<TResult>> f, A a, B b)
      {
         return await (await m).Map(async t => await f(t, a, b));
      }

      [DebuggerHidden]
      public static async Task<Data<TResult>> Map<T, A, B, C, TResult>(this Task<Data<T>> m, Func<T, A, B, C, Task<TResult>> f, A a, B b, C c)
      {
         return await (await m).Map(async t => await f(t, a, b, c));
      }

      // TEE #1

      [DebuggerHidden]
      public static Data<T> Tee<T, A>(this Data<T> m, Action<T, A> f, A a)
      {
         return m.Tee(t => f(t, a));
      }

      [DebuggerHidden]
      public static Data<T> Tee<T, A, B>(this Data<T> m, Action<T, A, B> f, A a, B b)
      {
         return m.Tee(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static Data<T> Tee<T, A, B, C>(this Data<T> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return m.Tee(t => f(t, a, b, c));                  
      }

      // TEE #2

      [DebuggerHidden]
      public static Task<Data<T>> Tea<T, A>(this Data<T> m, Func<T, A, Task> f, A a)
      {
         return m.Tea(t => f(t, a));
      }

      [DebuggerHidden]
      public static Task<Data<T>> Tea<T, A, B>(this Data<T> m, Func<T, A, B, Task> f, A a, B b)
      {
         return m.Tea(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static Task<Data<T>> Tea<T, A, B, C>(this Data<T> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return m.Tea(t => f(t, a, b, c));
      }

      // TEE EX #1

      [DebuggerHidden]
      public static async Task<Data<T>> Tee<T, A>(this Task<Data<T>> m, Action<T, A> f, A a)
      {
         return (await m).Tee(t => f(t, a));
      }

      [DebuggerHidden]
      public static async Task<Data<T>> Tee<T, A, B>(this Task<Data<T>> m, Action<T, A, B> f, A a, B b)
      {
         return (await m).Tee(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static async Task<Data<T>> Tee<T, A, B, C>(this Task<Data<T>> m, Action<T, A, B, C> f, A a, B b, C c)
      {
         return (await m).Tee(t => f(t, a, b, c));
      }

      // TEE EX #2

      [DebuggerHidden]
      public static async Task<Data<T>> Tea<T, A>(this Task<Data<T>> m, Func<T, A, Task> f, A a)
      {
         return await (await m).Tea(t => f(t, a));
      }

      [DebuggerHidden]
      public static async Task<Data<T>> Tea<T, A, B>(this Task<Data<T>> m, Func<T, A, B, Task> f, A a, B b)
      {
         return await (await m).Tea(t => f(t, a, b));
      }

      [DebuggerHidden]
      public static async Task<Data<T>> Tea<T, A, B, C>(this Task<Data<T>> m, Func<T, A, B, C, Task> f, A a, B b, C c)
      {
         return await (await m).Tea(t => f(t, a, b, c));
      }
   }
}

using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class ReturnEx
   {
      [DebuggerHidden]
      public static async Task<TResult> Call<T, TResult>(this Task<Return<T>> t, TResult r)
      {
         return (await t).Call(r);
      }

      [DebuggerHidden]
      public static async Task Ignore<T>(this Task<Return<T>> t)
      {
         (await t).Ignore();
      }

      [DebuggerHidden]
      public static async Task<Return<TResult>> Map<T, TResult>(this Task<Return<T>> t, Func<T, TResult> f)
      {
         return (await t).Map(f);
      }

      [DebuggerHidden]
      public static async Task<Return<TResult>> Map<T, TResult>(this Task<Return<T>> t, Func<T, Task<TResult>> f)
      {
         return await (await t).Map(f);         
      }

      [DebuggerHidden]
      public static async Task<Return<TResult>> MapTo<T, TResult>(this Task<Return<T>> t, Func<T, Return<TResult>> f)
      {
         return (await t).MapTo(f);         
      }

      [DebuggerHidden]
      public static async Task<Return<TResult>> MapTo<T, TResult>(this Task<Return<T>> t, Func<T, Task<Return<TResult>>> f)
      {
         return await (await t).MapTo(f);         
      }

      [DebuggerHidden]
      public static async Task<Return<T>> Tee<T>(this Task<Return<T>> t, Action<T> f)
      {
         return (await t).Tee(f);         
      }

      [DebuggerHidden]
      public static async Task<Return<T>> Tea<T>(this Task<Return<T>> t, Func<T, Task> f)
      {
         return await (await t).Tea(f);         
      }

      [DebuggerHidden]
      public static async Task<T> ValueOrDefault<T>(this Task<Return<T>> t, T @default = default(T))
      {
         return (await t).ValueOrDefault(@default);         
      }

      [DebuggerHidden]
      public static async Task<T> ValueOrDefault<T>(this Task<Return<T>> t, Func<T> f)
      {
         return (await t).ValueOrDefault(f);
      }

      [DebuggerHidden]
      public static async Task<T> ValueOrDefault<T>(this Task<Return<T>> t, Func<Task<T>> f)
      {
         return await (await t).ValueOrDefault(f);
      }

      public static async Task<T> ValueOrThrow<T>(this Task<Return<T>> t)
      {
         return (await t).ValueOrThrow();
      }      
   }
}

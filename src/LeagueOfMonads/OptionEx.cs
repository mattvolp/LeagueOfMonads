using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace LeagueOfMonads
{   
   public static class OptionEx
   {
      [DebuggerNonUserCode]
      public static T? ToNullable<T>(this Option<T> o)
         where T : struct
      {
         return o.Value;
      }

      [DebuggerNonUserCode]
      public static async Task<TResult> Call<T, TResult>(this Task<Option<T>> t, TResult r)
      {
         return (await t).Call(r);         
      }

      [DebuggerNonUserCode]
      public static async Task Ignore<T>(this Task<Option<T>> t)
      {
         (await t).Ignore();         
      }

      [DebuggerNonUserCode]
      public static async Task<Option<TResult>> Map<T, TResult>(this Task<Option<T>> t, Func<T, TResult> f)
      {
         return (await t).Map(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<Option<TResult>> Map<T, TResult>(this Task<Option<T>> t, Func<T, Task<TResult>> f)
      {
         return await (await t).Map(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<Option<TResult>> MapTo<T, TResult>(this Task<Option<T>> t, Func<T, Option<TResult>> f)
      {
         return (await t).MapTo(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<Option<TResult>> MapTo<T, TResult>(this Task<Option<T>> t, Func<T, Task<Option<TResult>>> f)
      {
         return await (await t).MapTo(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<Option<T>> Tee<T>(this Task<Option<T>> t, Action<T> f)
      {
         return (await t).Tee(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<Option<T>> Tea<T>(this Task<Option<T>> t, Func<T, Task> f)
      {
         return await (await t).Tea(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<T> ValueOrDefault<T>(this Task<Option<T>> t, T @default = default(T))
      {
         return (await t).ValueOrDefault(@default);         
      }

      [DebuggerNonUserCode]
      public static async Task<T> ValueOrDefault<T>(this Task<Option<T>> t, Func<T> f)
      {
         return (await t).ValueOrDefault(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<T> ValueOrDefault<T>(this Task<Option<T>> t, Func<Task<T>> f)
      {
         return await (await t).ValueOrDefault(f);         
      }

      [DebuggerNonUserCode]
      public static async Task<T> ValueOrThrow<T>(this Task<Option<T>> t, string error)
      {
         return (await t).ValueOrThrow(error);         
      }

      [DebuggerNonUserCode]
      public static async Task<T> ValueOrThrow<T, TException>(this Task<Option<T>> t, Func<TException> f)
         where TException : Exception
      {
         return (await t).ValueOrThrow(f);         
      }
   }
}
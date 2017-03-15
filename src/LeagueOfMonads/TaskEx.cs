using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class TaskEx
   {
      public static TResult Call<T, TResult>(this Task<T> t, TResult r)
      {
         return r;
      }


      public static async Task Ignore<T>(this Task<T> t)
      {
         await t;
      }


      public static async Task<TResult> Map<T, TResult>(this Task<T> t, Func<T, TResult> f)
      {
         return f(await t);
      }


      public static async Task<TResult> Map<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f)
      {
         return await f(await t);
      }


      public static async Task<TResult> MapTo<T, TResult>(this Task<T> t, Func<T, TResult> f)
      {
         return f(await t);
      }


      public static async Task<TResult> MapTo<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f)
      {
         return await f(await t);
      }


      public static async Task<T> Tee<T>(this Task<T> t, Action<T> f)
      {
         f(await t);
         return await t;
      }


      public static async Task<T> Tea<T>(this Task<T> t, Func<T, Task> f)
      {
         await f(await t);
         return await t;
      }


      public static async Task<T> ValueOrDefault<T>(this Task<T> t)
      {
         return await t;
      }
   }
}
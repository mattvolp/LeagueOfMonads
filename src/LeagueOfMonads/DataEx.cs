using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class DataEx
   {
      public static TResult Call<T, TResult>(this Task<Data<T>> t, TResult r)
      {
         return r;
      }

      public static Task Ignore<T>(this Task<Data<T>> t)
      {
         return Task.FromResult(0);
      }

      public static async Task<Data<TResult>> Map<T, TResult>(this Task<Data<T>> t, Func<T, TResult> f)
      {
         var o = await t;
         return f(o.Value);
      }

      public static async Task<Data<TResult>> Map<T, TResult>(this Task<Data<T>> t, Func<T, Task<TResult>> f)
      {
         var o = await t;
         return await f(o.Value);
      }

      public static async Task<Data<TResult>> MapTo<T, TResult>(this Task<Data<T>> t, Func<T, Data<TResult>> f)
      {
         var o = await t;
         return f(o.Value);
      }

      public static async Task<Data<TResult>> MapTo<T, TResult>(this Task<Data<T>> t, Func<T, Task<Data<TResult>>> f)
      {
         var o = await t;
         return await f(o.Value);
      }

      public static async Task<Data<T>> Tee<T>(this Task<Data<T>> t, Action<T> f)
      {
         var o = await t;
         f(o.Value);
         return o;
      }

      public static async Task<Data<T>> Tee<T>(this Task<Data<T>> t, Func<T, Task> f)
      {
         var o = await t;
         await f(o.Value);
         return o;
      }      
   }
}

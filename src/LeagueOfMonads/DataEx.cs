using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class DataEx
   {
      public static async Task<TResult> Call<T, TResult>(this Task<Data<T>> t, TResult r)
      {
         return (await t).Call(r);
      }


      public static async Task Ignore<T>(this Task<Data<T>> t)
      {
         (await t).Ignore();
      }


      public static async Task<Data<TResult>> Map<T, TResult>(this Task<Data<T>> t, Func<T, TResult> f)
      {
         return (await t).Map(f);
      }


      public static async Task<Data<TResult>> Map<T, TResult>(this Task<Data<T>> t, Func<T, Task<TResult>> f)
      {
         return await (await t).Map(f);
      }


      public static async Task<Data<T>> Tee<T>(this Task<Data<T>> t, Action<T> f)
      {
         return (await t).Tee(f);
      }


      public static async Task<Data<T>> Tea<T>(this Task<Data<T>> t, Func<T, Task> f)
      {
         return await (await t).Tea(f);
      }


      public static async Task<T> Value<T>(this Task<Data<T>> t)
      {
         return (await t).Value;
      }
   }
}
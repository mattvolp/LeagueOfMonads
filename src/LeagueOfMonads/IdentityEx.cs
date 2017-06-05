using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class IdentityEx
   {
      public static async Task<TResult> Call<T, TResult>(this Task<Identity<T>> t, TResult r)
      {
         return (await t).Call(r);
      }


      public static async Task Ignore<T>(this Task<Identity<T>> t)
      {
         (await t).Ignore();
      }


      public static async Task<Identity<TResult>> Map<T, TResult>(this Task<Identity<T>> t, Func<T, TResult> f)
      {
         return (await t).Map(f);
      }


      public static async Task<Identity<TResult>> Map<T, TResult>(this Task<Identity<T>> t, Func<T, Task<TResult>> f)
      {
         return await (await t).Map(f);
      }


      public static async Task<Identity<T>> Tee<T>(this Task<Identity<T>> t, Action<T> f)
      {
         return (await t).Tee(f);
      }


      public static async Task<Identity<T>> Tea<T>(this Task<Identity<T>> t, Func<T, Task> f)
      {
         return await (await t).Tea(f);
      }


      public static async Task<T> Value<T>(this Task<Identity<T>> t)
      {
         return (await t).Value;
      }
   }
}
using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class ResultAsync
   {
      public static async Task<TResult> Call<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, TResult r)
      {
         return (await t).Call(r);
      }


      public static async Task Ignore<T, TFailure>(this Task<Result<T, TFailure>> t)
      {
         (await t).Ignore();
      }


      public static async Task<Result<TResult, TFailure>> Map<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, TResult> f)
      {
         return (await t).Map(f);
      }


      public static async Task<Result<TResult, TFailure>> Map<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Task<TResult>> f)
      {
         return await (await t).Map(f);
      }


      public static async Task<Result<TResult, TFailure>> Map<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Result<TResult, TFailure>> f)
      {
         return (await t).Map(f);
      }


      public static async Task<Result<TResult, TFailure>> Map<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Task<Result<TResult, TFailure>>> f)
      {
         return await (await t).Map(f);
      }


      public static async Task<Result<T, TFailure>> Tee<T, TFailure>(this Task<Result<T, TFailure>> t, Action<T> f)
      {
         return (await t).Tee(f);
      }


      public static async Task<Result<T, TFailure>> Tea<T, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Task> f)
      {
         return await (await t).Tea(f);
      }


      public static async Task<T> ValueOrDefault<T, TFailure>(this Task<Result<T, TFailure>> t, T @default = default(T))
      {
         return (await t).ValueOrDefault(@default);
      }


      public static async Task<T> ValueOrDefault<T, TFailure>(this Task<Result<T, TFailure>> t, Func<T> f)
      {
         return (await t).ValueOrDefault(f);
      }


      public static async Task<T> ValueOrDefault<T, TFailure>(this Task<Result<T, TFailure>> t, Func<Task<T>> f)
      {
         return await (await t).ValueOrDefault(f);
      }

      public static async Task<T> ValueOrThrow<T, TFailure>(this Task<Result<T, TFailure>> t, Action<TFailure> f)
      {
         return (await t).ValueOrThrow(f);
      }
   }
}
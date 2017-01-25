using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class ResultEx
   {
      public static TResult Call<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, TResult r)
      {
         return r;
      }

      public static Task Ignore<T, TFailure>(this Task<Result<T, TFailure>> t)
      {
         return t;
      }

      public static async Task<Result<TResult, TFailure>> Map<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, TResult> f)
      {
         var o = await t;
         return o.Successful
            ? f(o.Value)
            : Result.Failure<TResult, TFailure>(o.Failure);
      }

      public static async Task<Result<TResult, TFailure>> Map<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Task<TResult>> f)
      {
         var o = await t;
         return o.Successful
            ? await f(o.Value)
            : Result.Failure<TResult, TFailure>(o.Failure);
      }

      public static async Task<Result<TResult, TFailure>> MapTo<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Result<TResult, TFailure>> f)
      {
         var o = await t;
         return o.Successful
            ? f(o.Value)
            : Result.Failure<TResult, TFailure>(o.Failure);         
      }

      public static async Task<Result<TResult, TFailure>> MapTo<T, TResult, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Task<Result<TResult, TFailure>>> f)
      {
         var o = await t;
         return o.Successful
            ? await f(o.Value)
            : Result.Failure<TResult, TFailure>(o.Failure);
      }

      public static async Task<Result<T, TFailure>> Tee<T, TFailure>(this Task<Result<T, TFailure>> t, Action<T> f)
      {
         var o = await t;
         if (o.Successful)
            f(o.Value);

         return o;
      }

      public static async Task<Result<T, TFailure>> Tee<T, TFailure>(this Task<Result<T, TFailure>> t, Func<T, Task> f)
      {
         var o = await t;
         if (o.Successful)
            await f(o.Value);

         return o;
      }

      public static async Task<T> ValueOrDefault<T, TFailure>(this Task<Result<T, TFailure>> t, T @default = default(T))
      {
         var o = await t;
         return o.Successful
            ? o.Value
            : @default;
      }

      public static async Task<T> ValueOrDefault<T, TFailure>(this Task<Result<T, TFailure>> t, Func<T> f)
      {
         var o = await t;
         return o.Successful
            ? o.Value
            : f();
      }

      public static async Task<T> ValueOrDefault<T, TFailure>(this Task<Result<T, TFailure>> t, Func<Task<T>> f)
      {
         var o = await t;
         return o.Successful
            ? o.Value
            : await f();
      }

      public static async Task<T> ValueOrThrow<T, TFailure>(this Task<Result<T, TFailure>> t, Action<TFailure> f)
      {
         var o = await t;
         if (!o.Successful)
         {
            f(o.Failure);
            throw new InvalidOperationException("failure action must throw here.");
         }

         return o.Value;
      }      
   }
}

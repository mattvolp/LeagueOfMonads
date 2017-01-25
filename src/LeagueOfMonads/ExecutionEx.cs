using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class ExecutionEx
   {
      public static TResult Call<T, TResult>(this Task<Execution<T>> t, TResult r)
      {
         return r;
      }

      public static Task Ignore<T>(this Task<Execution<T>> t)
      {
         return t;
      }

      public static async Task<Execution<TResult>> Map<T, TResult>(this Task<Execution<T>> t, Func<T, TResult> f)
      {
         var o = await t;
         return o.Successful
            ? f(o.Value)
            : Execution.Failure<TResult>(o.Failure);
      }

      public static async Task<Execution<TResult>> Map<T, TResult>(this Task<Execution<T>> t, Func<T, Task<TResult>> f)
      {
         var o = await t;
         return o.Successful
            ? await f(o.Value)
            : Execution.Failure<TResult>(o.Failure);
      }

      public static async Task<Execution<TResult>> MapTo<T, TResult>(this Task<Execution<T>> t, Func<T, Execution<TResult>> f)
      {
         var o = await t;
         return o.Successful
            ? f(o.Value)
            : Execution.Failure<TResult>(o.Failure);         
      }

      public static async Task<Execution<TResult>> MapTo<T, TResult>(this Task<Execution<T>> t, Func<T, Task<Execution<TResult>>> f)
      {
         var o = await t;
         return o.Successful
            ? await f(o.Value)
            : Execution.Failure<TResult>(o.Failure);
      }

      public static async Task<Execution<T>> Tee<T>(this Task<Execution<T>> t, Action<T> f)
      {
         var o = await t;
         if (o.Successful)
            f(o.Value);

         return o;
      }

      public static async Task<Execution<T>> Tee<T>(this Task<Execution<T>> t, Func<T, Task> f)
      {
         var o = await t;
         if (o.Successful)
            await f(o.Value);

         return o;
      }

      public static async Task<T> ValueOrDefault<T>(this Task<Execution<T>> t, T @default = default(T))
      {
         var o = await t;
         return o.Successful
            ? o.Value
            : @default;
      }

      public static async Task<T> ValueOrDefault<T>(this Task<Execution<T>> t, Func<T> f)
      {
         var o = await t;
         return o.Successful
            ? o.Value
            : f();
      }

      public static async Task<T> ValueOrDefault<T>(this Task<Execution<T>> t, Func<Task<T>> f)
      {
         var o = await t;
         return o.Successful
            ? o.Value
            : await f();
      }

      public static async Task<T> ValueOrThrow<T>(this Task<Execution<T>> t, string error)
      {
         var o = await t;
         if (o.Successful)
            return o.Value;

         throw new Exception(error);
      }

      public static async Task<T> ValueOrThrow<T, TException>(this Task<Execution<T>> t, Func<TException> f)
         where TException : Exception
      {
         var o = await t;
         if (o.Successful)
            return o.Value;

         throw f();
      }
   }
}

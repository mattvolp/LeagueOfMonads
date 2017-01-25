using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{   
   public static class OptionEx
   {
      public static T? ToNullable<T>(this Option<T> o)
         where T : struct
      {
         return o.Value;
      }

      public static TResult Call<T, TResult>(this Task<Option<T>> t, TResult r)
      {
         return r;
      }

      public static Task Ignore<T>(this Task<Option<T>> t)
      {
         return t;
      }

      public static async Task<Option<TResult>> Map<T, TResult>(this Task<Option<T>> t, Func<T, TResult> f)
      {
         var o = await t;
         return o.HasValue
            ? f(o.Value)
            : Option.None<TResult>();
      }

      public static async Task<Option<TResult>> Map<T, TResult>(this Task<Option<T>> t, Func<T, Task<TResult>> f)
      {
         var o = await t;
         return o.HasValue
            ? await f(o.Value)
            : Option.None<TResult>();
      }

      public static async Task<Option<TResult>> MapTo<T, TResult>(this Task<Option<T>> t, Func<T, Option<TResult>> f)
      {
         var o = await t;
         return o.HasValue
            ? f(o.Value)
            : Option.None<TResult>();         
      }

      public static async Task<Option<TResult>> MapTo<T, TResult>(this Task<Option<T>> t, Func<T, Task<Option<TResult>>> f)
      {
         var o = await t;
         return o.HasValue
            ? await f(o.Value)
            : Option.None<TResult>();         
      }

      public static async Task<Option<T>> Tee<T>(this Task<Option<T>> t, Action<T> f)
      {
         var o = await t;
         if (o.HasValue)
            f(o.Value);

         return o;
      }

      public static async Task<Option<T>> Tee<T>(this Task<Option<T>> t, Func<T, Task> f)
      {
         var o = await t;
         if (o.HasValue)
            await f(o.Value);

         return o;
      }

      public static async Task<T> ValueOrDefault<T>(this Task<Option<T>> t, T @default = default(T))
      {
         var o = await t;
         return o.HasValue
            ? o.Value
            : @default;
      }

      public static async Task<T> ValueOrDefault<T>(this Task<Option<T>> t, Func<T> f)
      {
         var o = await t;
         return o.HasValue
            ? o.Value
            : f();
      }

      public static async Task<T> ValueOrDefault<T>(this Task<Option<T>> t, Func<Task<T>> f)
      {
         var o = await t;
         return o.HasValue
            ? o.Value
            : await f();
      }

      public static async Task<T> ValueOrThrow<T>(this Task<Option<T>> t, string error)
      {
         var o = await t;
         if (o.HasValue)
            return o.Value;

         throw new Exception(error);
      }

      public static async Task<T> ValueOrThrow<T, TException>(this Task<Option<T>> t, Func<TException> f)
         where TException : Exception
      {
         var o = await t;
         if (o.HasValue)
            return o.Value;

         throw f();
      }
   }
}
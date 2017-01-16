using System;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public static class Tasks
   {
      public static TResult Call<T, TResult>(this Task<T> t, TResult r)
      {
         return r;
      }

      public static void Ignore<T>(this Task<T> t)
      {
         // noop
      }
      
      public static async Task<TResult> Map<T, TResult>(this Task<T> t, Func<T, TResult> f)
      {
         return f(await t);
      }

      public static async Task<TResult> MapOrCatch<T, TResult>(this Task<T> t, Func<T, TResult> f, Func<T, Exception, TResult> h)
      {
         try
         {
            return f(await t);
         }
         catch (Exception e)
         {
            return h(await t, e);
         }
      }

      public static async Task<TResult> MapOrCatch<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f, Func<T, Exception, TResult> h)
      {
         try
         {
            return await f(await t);
         }
         catch (Exception e)
         {
            return h(await t, e);
         }
      }

      public static async Task<TResult> MapOrCatch<T, TResult>(this Task<T> t, Func<T, TResult> f, Func<T, Exception, Task<TResult>> h)
      {
         try
         {
            return f(await t);
         }
         catch (Exception e)
         {
            return await h(await t, e);
         }
      }

      public static async Task<TResult> MapOrCatch<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f, Func<T, Exception, Task<TResult>> h)
      {
         try
         {
            return await f(await t);
         }
         catch (Exception e)
         {
            return await h(await t, e);
         }
      }

      public static async Task<TResult> MapOrThrow<T, TResult>(this Task<T> t, Func<T, TResult> f, Action<T, Exception> h)
      {
         try
         {
            return f(await t);
         }
         catch (Exception e)
         {
            h(await t, e);
            throw;
         }
      }

      public static async Task<TResult> MapOrThrow<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f, Action<T, Exception> h)
      {
         try
         {
            return await f(await t);
         }
         catch (Exception e)
         {
            h(await t, e);
            throw;
         }
      }

      public static async Task<TResult> MapOrThrow<T, TResult>(this Task<T> t, Func<T, TResult> f, Func<T, Exception, Task> h)
      {
         try
         {
            return f(await t);
         }
         catch (Exception e)
         {
            await h(await t, e);
            throw;
         }
      }

      public static async Task<TResult> MapOrThrow<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f, Func<T, Exception, Task> h)
      {
         try
         {
            return await f(await t);
         }
         catch (Exception e)
         {
            await h(await t, e);
            throw;
         }
      }

      public static async Task<TResult> MapTo<T, TResult>(this Task<T> t, Func<T, Task<TResult>> f)
      {
         return await f(await t);
      }

      public static async Task<T> Tee<T>(this Task<T> t, Func<T, Task> f)
      {
         await f(await t);
         return await t;
      }

      public static async Task<T> Tee<T>(this Task<T> t, Action<T> f)
      {
         f(await t);
         return await t;
      }

      public static async Task<T> TeeOrCatch<T>(this Task<T> t, Action<T> f, Action<T, Exception> h)
      {
         try
         {
            f(await t);
         }
         catch (Exception e)
         {
            h(await t, e);
         }

         return await t;
      }

      public static async Task<T> TeeOrCatch<T>(this Task<T> t, Func<T, Task> f, Action<T, Exception> h)
      {
         try
         {
            await f(await t);
         }
         catch (Exception e)
         {
            h(await t, e);
         }

         return await t;
      }

      public static async Task<T> TeeOrCatch<T>(this Task<T> t, Action<T> f, Func<T, Exception, Task> h)
      {
         try
         {
            f(await t);
         }
         catch (Exception e)
         {
            await h(await t, e);
         }

         return await t;
      }

      public static async Task<T> TeeOrCatch<T>(this Task<T> t, Func<T, Task> f, Func<T, Exception, Task> h)
      {
         try
         {
            await f(await t);
         }
         catch (Exception e)
         {
            await h(await t, e);
         }

         return await t;
      }

      public static async Task<T> TeeOrThrow<T>(this Task<T> t, Action<T> f, Action<T, Exception> h)
      {
         try
         {
            f(await t);
            return await t;
         }
         catch (Exception e)
         {
            h(await t, e);
            throw;
         }
      }

      public static async Task<T> TeeOrThrow<T>(this Task<T> t, Func<T, Task> f, Action<T, Exception> h)
      {
         try
         {
            await f(await t);
            return await t;
         }
         catch (Exception e)
         {
            h(await t, e);
            throw;
         }
      }

      public static async Task<T> TeeOrThrow<T>(this Task<T> t, Action<T> f, Func<T, Exception, Task> h)
      {
         try
         {
            f(await t);
            return await t;
         }
         catch (Exception e)
         {
            await h(await t, e);
            throw;
         }
      }

      public static async Task<T> TeeOrThrow<T>(this Task<T> t, Func<T, Task> f, Func<T, Exception, Task> h)
      {
         try
         {
            await f(await t);
            return await t;
         }
         catch (Exception e)
         {
            await h(await t, e);
            throw;
         }
      }

      #region contructors



      #endregion
   }
}

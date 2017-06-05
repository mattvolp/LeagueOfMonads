#if EXPERIMENTAL

using System;
using System.Threading.Tasks;
using LeagueOfMonads.NoLambda;

// ReSharper disable UnusedVariable
// ReSharper disable UnusedMember.Local
// ReSharper disable UnusedParameter.Local

#pragma warning disable 1998

namespace LeagueOfMonads.Experimental
{
   internal class Test
   {

      public async Task X()
      {
         var d = Identity.Create(3)
            .Map(Y, false);
      }

      private static string Y(int i, bool b)
      {
         return i.ToString();
      }

      internal async Task X2()
      {
         var o = new Option<int>(42);

         var x = await o
            .Map(Inc)
            .Map(IncA)
            .Map(Inc2, "")
            .Map(IncA2, "")
            .ValueOrDefault();
      }

      internal void X3()
      {
         //Identity.Create(3)
         //   .Join("x")
         //   .Map(Inc2);

         //Join.Create(3, "x")
         //   .Map(Inc2);
      }

      internal void X4()
      {
         var x = Identity.Create(3)
            .Tee(TeeMe)
            .Tea(TeeMeA)
            .Tee(TeeMe);
      }

      internal async Task X5()
      {
         var x = await Option.Create(1)
            .Map(MaybeAdd, 2)
            .Map(MaybeAdd, 3)
            .Map(MaybeAddA, 4)
            .Map(MaybeAdd, 5)
            .Map(Inc3, 6);
      }

      internal async Task X6()
      {
         var x = await Return.Create(1)
            .Map(ReturnAdd, 2)
            .Map(ReturnAdd, 3)
            .Map(ReturnAddA, 4)
            .Map(ReturnAdd, 5)
            .Map(Inc3, 6);
      }

      internal async Task X7()
      {
         var x = await Result.Create<int, Exception>(1)
            .Map(ResultAdd, 2)
            .Map(ResultAdd, 3)
            .Map(ResultAddA, 4)
            .Map(ResultAdd, 5)
            .Map(Inc3, 6);
      }

      internal void X8()
      {
         //var r = ResultAdd(1, 2)
         //   .Either(n => n, e => e);
      }

      private Result<int, Exception> ResultAdd(int value, int increment)
      {
         return value + increment;
      }

      private Task<Result<int, Exception>> ResultAddA(int value, int increment)
      {
         return Task.FromResult(Result.Success<int, Exception>(value + increment));
      }

      private Return<int> ReturnAdd(int value, int increment)
      {
         return value + increment;
      }

      private Task<Return<int>> ReturnAddA(int value, int increment)
      {
         return Task.FromResult(Return.Success(value + increment));
      }

      private Option<int> MaybeAdd(int value, int increment)
      {
         return value + increment;
      }

      private Task<Option<int>> MaybeAddA(int value, int increment)
      {
         return Task.FromResult(Option.Create(value + increment));
      }

      private void TeeMe(int i)
      {
         //
      }

      private Task TeeMeA(int i)
      {
         return Task.FromResult(i);
      }

      private Option<int> Poop(int arg1, Exception arg2)
      {
         throw new NotImplementedException();
      }

      private Task<Option<int>> PoopA(int arg1, Exception arg2)
      {
         throw new NotImplementedException();
      }

      private static int Inc3(int v, int i)
      {
         return v + i;
      }

      private static int Inc(int v)
      {
         return v + 1;
      }

      private static int Inc2(int v, string x)
      {
         return v + 1;
      }

      private static Task<int> IncA(int v)
      {
         return Task.FromResult(v + 1);
      }

      private static Task<int> IncA2(int v, string s)
      {
         return Task.FromResult(v + 1);
      }

      private static Task<int> DefaultA()
      {
         return Task.FromResult(1);
      }

      private static ApplicationException MyError()
      {
         return new ApplicationException("Asdfasdf");
      }
   }

   public static class Lift
   {
      public static Func<T, Exception, Task<Option<TResult>>> Async<T, TResult>(Func<T, Exception, Option<TResult>> f)
      {
         return (t, e) => Task.FromResult(f(t, e));
      }
   }
}

#pragma warning restore 1998
#endif
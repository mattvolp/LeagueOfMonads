#if EXPERIMENTAL

using System;
using LeagueOfMonads.NoLambda;
using System.Threading.Tasks;

namespace LeagueOfMonads.Experimental
{
   internal class Test
   {
      public async Task X()
      {
         var d = Data.Create(3)
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
         //Data.Create(3)
         //   .Join("x")
         //   .Map(Inc2);

         //Join.Create(3, "x")
         //   .Map(Inc2);
      }

      internal void X4()
      {
         var x = Data.Create(3)
            .Tee(TeeMe)
            .Tea(TeeMeA)
            .Tee(TeeMe);
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

#endif

using System;

#if EXPERIMENTAL

namespace LeagueOfMonads.Experimental
{
   public class Reval<T>
   {      
      private readonly Func<T> _func;
      private Lazy<T> _lazy;

      internal Reval(Func<T> func)
      {
         _func = func;
         _lazy = new Lazy<T>(func);
      }

      public T Value => _lazy.Value;

      public void Reset()
      {
         _lazy = new Lazy<T>(_func);
      }
   }

   public static class Reval
   {
      public static Reval<T> Create<T>(Func<T> func)
      {
         return new Reval<T>(func);
      }
   }
}

#endif
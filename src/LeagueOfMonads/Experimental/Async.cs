#if EXPERIMENTAL

using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LeagueOfMonads.Experimental
{
   public class Async<T>
   {
      private readonly Lazy<Task<T>> instance;
      
      public Async(Func<Task<T>> factory)
      {
         instance = new Lazy<Task<T>>(factory, true);
      }

      public TaskAwaiter<T> GetAwaiter()
      {
         return instance.Value.GetAwaiter();
      }
   }
}

#endif
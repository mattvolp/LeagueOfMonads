using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   public class Lasync<T>
   {
      private readonly Func<Task<T>> _factory;
      private Lazy<Task<T>> _value;

      public Task<T> Task => _value.Value;

      public Lasync(Func<Task<T>> factory)
      {
         _factory = factory;
         _value = new Lazy<Task<T>>(factory, true);
      }

      public void Reset()
      {
         _value = new Lazy<Task<T>>(_factory, true);
      }


      public TaskAwaiter<T> GetAwaiter()
      {
         return _value.Value.GetAwaiter();
      }
   }

   public static class Lasync
   {
      public static Lasync<T> Create<T>(Func<Task<T>> f)
      {
         return new Lasync<T>(f);
      }
   }
}
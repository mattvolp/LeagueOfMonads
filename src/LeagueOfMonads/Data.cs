using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   [DataContract]
   public class Data<T>
      : IEnumerable<T>
   {
      [DataMember] public readonly T Value;

      public Data(IEnumerable<T> e)
      {
         Value = e.Single();
      }

      public Data(T value)
      {
         Value = value;
      }


      public virtual TResult Call<TResult>(TResult r)
      {
         return r;
      }

      
      public virtual void Ignore()
      {
         // noop
      }

      //public virtual Join<T, T2> Join<T2>(T2 value)
      //{
      //   return new Join<T, T2>(Value, value);
      //}

      
      public virtual Data<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return f(Value);
      }


      public virtual async Task<Data<TResult>> Map<TResult>(Func<T, Task<TResult>> f)
      {
         return await f(Value);
      }


      public virtual Data<T> Tee(Action<T> f)
      {
         f(Value);
         return this;
      }


      public virtual async Task<Data<T>> Tea(Func<T, Task> f)
      {
         await f(Value);
         return this;
      }

      public virtual IEnumerator<T> GetEnumerator()
      {
         yield return Value;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public static implicit operator Data<T>(T value)
      {
         return new Data<T>(value);
      }
   }

   public static class Data
   {
      public static Data<T> Create<T>(T value)
      {
         return new Data<T>(value);
      }
   }
}
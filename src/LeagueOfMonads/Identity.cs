using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LeagueOfMonads
{
   [DataContract]
   public class Identity<T>
   {
      [DataMember] public readonly T Value;

      [JsonConstructor]
      internal Identity(T value)
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

      
      public virtual Identity<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return f(Value);
      }


      public virtual async Task<Identity<TResult>> Map<TResult>(Func<T, Task<TResult>> f)
      {
         return await f(Value);
      }


      public virtual Identity<T> Tee(Action<T> f)
      {
         f(Value);
         return this;
      }


      public virtual async Task<Identity<T>> Tea(Func<T, Task> f)
      {
         await f(Value);
         return this;
      }

      public static implicit operator Identity<T>(T value)
      {
         return new Identity<T>(value);
      }
   }

   public static class Identity
   {
      public static Identity<T> Create<T>(T value)
      {
         return new Identity<T>(value);
      }
   }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   [DataContract]
   public class Option<T>
      : IEnumerable<T>
   {
      [DataMember] public readonly bool HasValue;
      [DataMember] public readonly T Value;

      public Option(IEnumerable<T> e)
      {
         // ReSharper disable PossibleMultipleEnumeration
         HasValue = e.Any();
         Value = e.SingleOrDefault();
      }

      public Option()
      {
         HasValue = false;
      }

      public Option(T value)
      {
         HasValue = !Equals(null, value);
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


      public virtual Option<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return HasValue
            ? f(Value)
            : Option.None<TResult>();
      }


      public virtual async Task<Option<TResult>> Map<TResult>(Func<T, Task<TResult>> f)
      {
         return HasValue
            ? await f(Value)
            : Option.None<TResult>();
      }


      public virtual Option<TResult> Map<TResult>(Func<T, Option<TResult>> f)
      {
         return HasValue
            ? f(Value)
            : Option.None<TResult>();
      }


      public virtual async Task<Option<TResult>> Map<TResult>(Func<T, Task<Option<TResult>>> f)
      {
         return HasValue
            ? await f(Value)
            : Option.None<TResult>();
      }


      public virtual Option<T> Tee(Action<T> f)
      {
         if (HasValue)
            f(Value);

         return this;
      }


      public virtual async Task<Option<T>> Tea(Func<T, Task> f)
      {
         if (HasValue)
            await f(Value);

         return this;
      }


      public virtual T ValueOrDefault(T @default = default(T))
      {
         return HasValue
            ? Value
            : @default;
      }


      public virtual T ValueOrDefault(Func<T> f)
      {
         return HasValue
            ? Value
            : f();
      }


      public virtual async Task<T> ValueOrDefault(Func<Task<T>> f)
      {
         return HasValue
            ? Value
            : await f();
      }

      public virtual T ValueOrThrow(string error)
      {
         if (HasValue)
            return Value;

         throw new Exception(error);
      }

      public virtual T ValueOrThrow<TException>(Func<TException> f)
         where TException : Exception
      {
         if (HasValue)
            return Value;

         throw f();
      }

      public virtual IEnumerator<T> GetEnumerator()
      {
         if (HasValue)
            yield return Value;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public static implicit operator Option<T>(T value)
      {
         return new Option<T>(value);
      }
   }

   public static class Option
   {
      public static Option<T> Create<T>(T value)
      {
         return new Option<T>(value);
      }

      public static Option<T> Some<T>(T value)
      {
         return new Option<T>(value);
      }

      public static Option<T> None<T>()
      {
         return new Option<T>();
      }      
   }
}
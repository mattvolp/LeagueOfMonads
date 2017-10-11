using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   [DataContract]
   public class Option<T>
   {
      [DataMember] public readonly bool HasValue;
      [DataMember] public readonly T Value;

      public Option(bool hasValue, T value)
      {
         HasValue = hasValue;
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

      public static implicit operator Option<T>(T value)
      {
         return new Option<T>(!Equals(null, value), value);
      }
   }

   public static class Option
   {
      public static Option<T> Create<T>(T value)
      {
         return new Option<T>(!Equals(null, value), value);
      }

      public static Option<T> Some<T>(T value)
      {
         return new Option<T>(!Equals(null, value), value);
      }

      public static Option<T> None<T>()
      {
         return new Option<T>(false, default(T));
      }      
   }
}
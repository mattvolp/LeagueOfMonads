using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LeagueOfMonads
{
   [DataContract]
   public class Option<T>
      : IEnumerable<T>
   {
      [DataMember] public readonly bool HasValue;
      [DataMember] public readonly T Value;

      public Option()
      {
         HasValue = false;
      }

      public Option(T value)
      {
         HasValue = Equals(null, value);
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
            ? Option.Some(f(Value))
            : Option.None<TResult>();
      }

      public virtual Option<TResult> MapOrCatch<TResult>(Func<T, TResult> f, Func<T, Exception, Option<TResult>> handler)
      {
         try
         {
            return HasValue
               ? f(Value)
               : Option.None<TResult>();

         }
         catch (Exception e)
         {
            return handler(Value, e);
         }
      }

      public virtual Option<TResult> MapOrThrow<TResult>(Func<T, TResult> f, Action<T, Exception> handler)
      {
         try
         {
            return f(Value);
         }
         catch (Exception e)
         {
            handler(Value, e);
            throw;
         }
      }
      
      public virtual Option<TResult> MapTo<TResult>(Func<T, Option<TResult>> f)
      {
         return f(Value);
      }

      public virtual Option<T> Tee(Action<T> f)
      {
         if (HasValue)
            f(Value);

         return this;
      }

      public virtual Option<T> TeeOrCatch(Action<T> f, Action<T, Exception> handler)
      {
         try
         {
            if (HasValue)
               f(Value);            
         }
         catch (Exception e)
         {
            handler(Value, e);
         }

         return this;
      }

      public virtual Option<T> TeeOrThrow(Action<T> f, Action<T, Exception> handler)
      {
         try
         {
            if (HasValue)
               f(Value);

            return this;
         }
         catch (Exception e)
         {
            handler(Value, e);
            throw;
         }
      }
      
      public virtual T ValueOrDefault(T @default = default(T))
      {
         return HasValue
            ? Value
            : @default;
      }

      public virtual T ValueOrThrow(string error)
      {
         if (HasValue)
            return Value;

         throw new Exception(error);
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
      public static Option<T> Some<T>(T value)
      {
         return new Option<T>(value);
      }

      public static Option<T> None<T>()
      {
         return new Option<T>();
      }

      public static Option<T> From<T>(T value)
      {
         return new Option<T>(value);
      }
      
      public static T? ToNullable<T>(this Option<T> o)
         where T : struct
      {
         return o.Value;
      }      
   }   
}
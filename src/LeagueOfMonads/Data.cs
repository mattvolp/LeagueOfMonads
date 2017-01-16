using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace LeagueOfMonads
{      
   [DataContract]
   public class Data<T> 
      : IEnumerable<T> 
   {
      [DataMember] public readonly T Value;

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

      public virtual Data<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return new Data<TResult>(f(Value));
      }

      public virtual Data<TResult> MapOrCatch<TResult>(Func<T, TResult> f, Func<T, Exception, Data<TResult>> handler)
      {
         try
         {
            return f(Value);
         }
         catch (Exception e)
         {
            return handler(Value, e);
         }
      }

      public virtual Data<TResult> MapOrThrow<TResult>(Func<T, TResult> f, Action<T, Exception> handler)
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
      
      public virtual Data<T> Tee(Action<T> f)
      {
         f(Value);
         return this;
      }

      public virtual Data<T> TeeOrCatch(Action<T> f, Action<T, Exception> handler)
      {
         try
         {
            f(Value);
         }
         catch (Exception e)
         {
            handler(Value, e);
         }

         return this;
      }

      public virtual Data<T> TeeOrThrow(Action<T> f, Action<T, Exception> handler)
      {
         try
         {
            f(Value);
         }
         catch (Exception e)
         {
            handler(Value, e);
            throw;
         }

         return this;
      }

      public virtual T ValueOrDefault(T @default)
      {
         return Value;
      }

      public virtual T ValueOrThrow(string error)
      {
         return Value;
      }

      public virtual IEnumerator<T> GetEnumerator()
      {
         yield return Value;
      }

      IEnumerator IEnumerable.GetEnumerator()
      {
         return GetEnumerator();
      }

      public static implicit operator T(Data<T> d)
      {
         return d.Value;
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
using System;
using System.Runtime.Serialization;

namespace LeagueOfMonads
{
   [DataContract]
   public class Result<T>
   {
      [DataMember] public readonly bool Successful;
      [DataMember] public readonly T Value;
      [DataMember] public readonly Exception Failure;

      public Result(T value)
      {
         Value = value;
         Successful = true;
      }

      public Result(Exception failure)
      {
         Failure = failure;
         Successful = false;
      }

      public virtual TResult Call<TResult>(TResult x)
      {
         return x;
      }

      public virtual void Ignore()
      {
         // noop
      }

      public virtual Result<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return Successful
            ? f(Value)
            : Result.Fail<TResult>(Failure);
      }
      
      public virtual Result<TResult> MapOrCatch<TResult>(Func<T, TResult> f, Func<T, Exception, TResult> h)
      {
         try
         {
            return Successful
               ? f(Value)
               : Result.Fail<TResult>(Failure);
         }
         catch (Exception e)
         {
            return h(Value, e);
         }
      }

      public virtual Result<TResult> MapOrThrow<TResult>(Func<T, TResult> f, Action<T, Exception> h)
      {
         try
         {
            return Successful
               ? f(Value)
               : Result.Fail<TResult>(Failure);
         }
         catch (Exception e)
         {
            h(Value, e);
            throw;
         }
      }

      public virtual Result<T> Tee(Action<T> a)
      {
         a(Value);
         return this;
      }

      public virtual Result<T> TeeOrCatch(Action<T> f, Action<T, Exception> h)
      {
         try
         {
            if (Successful)
               f(Value);
         }
         catch (Exception e)
         {
            h(Value, e);
         }

         return this;
      }

      public virtual Result<T> TeeOrThrow(Action<T> f, Action<T, Exception> h)
      {
         try
         {
            if (Successful)
               f(Value);
            return this;
         }
         catch (Exception e)
         {
            h(Value, e);
            throw;
         }
      }
      
      public virtual T ValueOrDefault(T @default = default(T))
      {
         return Successful
            ? Value
            : @default;
      }

      public virtual T ValueOrThrow()
      {
         if (Successful)
            return Value;

         throw Failure;
      }

      // multitype functions

      public virtual Result<TResult> MapAll<TResult>(Func<T, TResult> f, Func<Exception, TResult> e)
      {
         return Successful
            ? f(Value)
            : e(Failure);
      }

      // custom functions

      public virtual Result<TResult> TryMap<TResult>(Func<T, TResult> f)
      {
         try
         {
            return Successful
               ? f(Value)
               : Result.Fail<TResult>(Failure);
         }
         catch (Exception e)
         {
            return e;
         }
      }

      public virtual Result<T> TryTee(Action<T> f)
      {
         try
         {
            if (Successful)
               f(Value);
            return this;
         }
         catch (Exception e)
         {
            return e;
         }
      }
      
      public static implicit operator Result<T>(T value)
      {
         return new Result<T>(value);
      }

      public static implicit operator Result<T>(Exception failure)
      {
         return new Result<T>(failure);
      }
   }
   
   public static class Result
   {
      public static Result<T> Succeed<T>(T value) 
      {
         return new Result<T>(value);
      }

      public static Result<T> Fail<T>(Exception e)
      {
         return new Result<T>(e);
      }
   }   
}

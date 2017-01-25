using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   [DataContract]
   public class Execution<T>
   {
      [DataMember] public readonly bool Successful;
      [DataMember] public readonly T Value;
      [DataMember] public readonly Exception Failure;

      public Execution(T value)
      {
         Value = value;
         Successful = true;
      }

      public Execution(Exception failure)
      {
         Failure = failure;
         Successful = false;
      }

      public virtual TResult Call<TResult>(TResult r)
      {
         return r;
      }
      
      public virtual void Ignore()
      {
         // noop
      }

      public virtual Execution<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return Successful
            ? f(Value)
            : Execution.Failure<TResult>(Failure);
      }

      public virtual async Task<Execution<TResult>> Map<TResult>(Func<T, Task<TResult>> f)
      {
         return Successful
            ? await f(Value)
            : Execution.Failure<TResult>(Failure);
      }

      public virtual Execution<TResult> MapTo<TResult>(Func<T, Execution<TResult>> f)
      {
         return Successful
            ? f(Value)
            : Execution.Failure<TResult>(Failure);         
      }

      public virtual async Task<Execution<TResult>> MapTo<TResult>(Func<T, Task<Execution<TResult>>> f)
      {
         return Successful
            ? await f(Value)
            : Execution.Failure<TResult>(Failure);         
      }

      public virtual Execution<T> Tee(Action<T> f)
      {
         if (Successful)
            f(Value);

         return this;
      }

      public virtual async Task<Execution<T>> Tee(Func<T, Task> f)
      {
         if (Successful)
            await f(Value);

         return this;
      }

      public virtual T ValueOrDefault(T @default = default(T))
      {
         return Successful
            ? Value
            : @default;
      }

      public virtual T ValueOrDefault(Func<T> f)
      {
         return Successful
            ? Value
            : f();
      }

      public virtual async Task<T> ValueOrDefault(Func<Task<T>> f)
      {
         return Successful
            ? Value
            : await f();
      }

      public virtual T ValueOrThrow()
      {
         if (Successful)
            return Value;

         throw Failure;
      }
      
      public static implicit operator Execution<T>(T value)
      {
         return new Execution<T>(value);
      }

      public static implicit operator Execution<T>(Exception failure)
      {
         return new Execution<T>(failure);
      }
   }
   
   public static class Execution
   {
      public static Execution<T> Success<T>(T value) 
      {
         return new Execution<T>(value);
      }

      public static Execution<T> Failure<T>(Exception e)
      {
         return new Execution<T>(e);
      }

      public static Execution<T> Failure<T>(string message)
      {         
         return new Execution<T>(new Exception(message));
      }
   }   
}

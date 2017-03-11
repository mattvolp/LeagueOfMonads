using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   [DataContract]
   public class Return<T>
   {
      [DataMember] public readonly bool Successful;
      [DataMember] public readonly T Value;
      [DataMember] public readonly Exception Failure;

      public Return(T value)
      {
         Value = value;
         Successful = true;
      }

      public Return(Exception failure)
      {
         Failure = failure;
         Successful = false;
      }

      [DebuggerHidden]
      public virtual TResult Call<TResult>(TResult r)
      {
         return r;
      }

      [DebuggerHidden]
      public virtual void Ignore()
      {
         // noop
      }

      [DebuggerHidden]
      public virtual Return<TResult> Map<TResult>(Func<T, TResult> f)
      {
         return Successful
            ? f(Value)
            : Return.Failure<TResult>(Failure);
      }

      [DebuggerHidden]
      public virtual async Task<Return<TResult>> Map<TResult>(Func<T, Task<TResult>> f)
      {
         return Successful
            ? await f(Value)
            : Return.Failure<TResult>(Failure);
      }

      [DebuggerHidden]
      public virtual Return<TResult> MapTo<TResult>(Func<T, Return<TResult>> f)
      {
         return Successful
            ? f(Value)
            : Return.Failure<TResult>(Failure);         
      }

      [DebuggerHidden]
      public virtual async Task<Return<TResult>> MapTo<TResult>(Func<T, Task<Return<TResult>>> f)
      {
         return Successful
            ? await f(Value)
            : Return.Failure<TResult>(Failure);         
      }

      [DebuggerHidden]
      public virtual Return<T> Tee(Action<T> f)
      {
         if (Successful)
            f(Value);

         return this;
      }

      [DebuggerHidden]
      public virtual async Task<Return<T>> Tea(Func<T, Task> f)
      {
         if (Successful)
            await f(Value);

         return this;
      }

      [DebuggerHidden]
      public virtual T ValueOrDefault(T @default = default(T))
      {
         return Successful
            ? Value
            : @default;
      }

      [DebuggerHidden]
      public virtual T ValueOrDefault(Func<T> f)
      {
         return Successful
            ? Value
            : f();
      }

      [DebuggerHidden]
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
      
      public static implicit operator Return<T>(T value)
      {
         return new Return<T>(value);
      }

      public static implicit operator Return<T>(Exception failure)
      {
         return new Return<T>(failure);
      }
   }
   
   public static class Return
   {
      public static Return<T> Success<T>(T value) 
      {
         return new Return<T>(value);
      }

      public static Return<T> Failure<T>(Exception e)
      {
         return new Return<T>(e);
      }

      public static Return<T> Failure<T>(string message)
      {         
         return new Return<T>(new Exception(message));
      }
   }   
}

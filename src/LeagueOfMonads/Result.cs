using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace LeagueOfMonads
{
   [DataContract]
   public class Result<T, TFailure>
   {
      [DataMember] public readonly bool Successful;
      [DataMember] public readonly T Value;
      [DataMember] public readonly TFailure Failure;

      public Result(T value)
      {
         Value = value;
         Successful = true;
      }

      public Result(TFailure failure)
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


      public virtual Result<TResult, TFailure> Map<TResult>(Func<T, TResult> f)
      {
         return Successful
            ? f(Value)
            : Result.Failure<TResult, TFailure>(Failure);
      }


      public virtual async Task<Result<TResult, TFailure>> Map<TResult>(Func<T, Task<TResult>> f)
      {
         return Successful
            ? await f(Value)
            : Result.Failure<TResult, TFailure>(Failure);
      }


      public virtual Result<TResult, TFailure> Map<TResult>(Func<T, Result<TResult, TFailure>> f)
      {
         return Successful
            ? f(Value)
            : Result.Failure<TResult, TFailure>(Failure);
      }


      public virtual async Task<Result<TResult, TFailure>> Map<TResult>(Func<T, Task<Result<TResult, TFailure>>> f)
      {
         return Successful
            ? await f(Value)
            : Result.Failure<TResult, TFailure>(Failure);
      }


      public virtual Result<T, TFailure> Tee(Action<T> f)
      {
         if (Successful)
            f(Value);

         return this;
      }


      public virtual async Task<Result<T, TFailure>> Tea(Func<T, Task> f)
      {
         if (Successful)
            await f(Value);

         return this;
      }

      public virtual Result<TResult, TFailure> Either<TResult>(Func<T, TResult> success, Func<TFailure, TResult> failure)
      {
         return Successful
            ? success(Value)
            : failure(Failure);
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

      public virtual T ValueOrThrow(Action<TFailure> f)
      {
         if (!Successful)
         {
            f(Failure);
            throw new InvalidOperationException("failure action must throw here.");
         }

         return Value;
      }

      public static implicit operator Result<T, TFailure>(T value)
      {
         return new Result<T, TFailure>(value);
      }

      public static implicit operator Result<T, TFailure>(TFailure failure)
      {
         return new Result<T, TFailure>(failure);
      }
   }

   public static class Result
   {
      public static Result<T, TFailure> Create<T, TFailure>(T value)
      {
         return new Result<T, TFailure>(value);
      }

      public static Result<T, TFailure> Success<T, TFailure>(T value)
      {
         return new Result<T, TFailure>(value);
      }

      public static Result<T, TFailure> Failure<T, TFailure>(TFailure e)
      {
         return new Result<T, TFailure>(e);
      }
   }
}
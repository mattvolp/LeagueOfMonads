//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using System.Threading.Tasks;

//namespace LeagueOfMonads
//{      
//   [DataContract]
//   public class Join<T1, T2> 
//      : IEnumerable<Tuple<T1, T2>> 
//   {
//      [DataMember] public readonly Tuple<T1, T2> Value;

//      public Join(T1 value1, T2 value2)
//      {
//         Value = Tuple.Create(value1, value2);
//      }

//      public virtual TResult Call<TResult>(TResult r)
//      {
//         return r;
//      }
      
//      public virtual void Ignore()
//      {
//         // noop
//      }

//      public virtual Join<TResult, T2> Map<TResult>(Func<T1, T2, TResult> f)
//      {
//         return Join.Create(
//            f(Value.Item1, Value.Item2),
//            Value.Item2);
//      }

//      public virtual async Task<Join<TResult, T2>> Map<TResult>(Func<T1, T2, Task<TResult>> f)
//      {
//         return Join.Create(
//            await f(Value.Item1, Value.Item2),
//            Value.Item2);
//      }

//      public virtual Join<T1, T2> Tee(Action<T1, T2> f)
//      {
//         f(Value.Item1, Value.Item2);
//         return this;
//      }

//      public virtual async Task<Join<T1, T2>> Tea(Func<T1, T2, Task> f)
//      {
//         await f(Value.Item1, Value.Item2);
//         return this;
//      }
      
//      public virtual IEnumerator<Tuple<T1, T2>> GetEnumerator()
//      {
//         yield return Value;
//      }

//      IEnumerator IEnumerable.GetEnumerator()
//      {
//         return GetEnumerator();
//      }
      
//      //public static implicit operator Join<T, T2>(T value)
//      //{
//      //   return new Join<T, T2>(value, Value);
//      //}
//   }

//   public static class Join
//   {       
//      public static Join<T1, T2> Create<T1, T2>(T1 value1, T2 value2)
//      {
//         return new Join<T1, T2>(value1, value2);
//      }
//   }
//}
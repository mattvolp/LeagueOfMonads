using System;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

// ReSharper disable InconsistentNaming
namespace LeagueOfMonads
{
   [DataContract]
   public abstract class Union<TA>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly int Tag;

      [JsonConstructor]      
      protected Union(TA item) { A = item; Tag = 0; }
      
      public T Map<T>(Func<TA, T> fa)
      {
         switch (Tag)
         {
            case 0: return fa(A);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa)
      {
         switch (Tag)
         {
            case 0: return await fa(A);            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa)
      {
         switch (Tag)
         {
            case 0: fa(A); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa)
      {
         switch (Tag)
         {
            case 0: await fa(A); break;            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }

   [DataContract]
   public abstract class Union<TA, TB>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly TB B;
      [DataMember] public readonly int Tag;

      [JsonConstructor]
      private Union(TA a, TB b)
      {
         A = a;
         B = b;
         Tag = A != null ? 0 : 1;
      }

      protected Union(TA item) { A = item; Tag = 0; }
      protected Union(TB item) { B = item; Tag = 1; }

      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb)
      {
         switch (Tag)
         {
            case 0: return fa(A);
            case 1: return fb(B);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb)
      {
         switch (Tag)
         {
            case 0: return await fa(A);
            case 1: return await fb(B);            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb)
      {
         switch (Tag)
         {
            case 0: fa(A); break;
            case 1: fb(B); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb)
      {
         switch (Tag)
         {
            case 0: await fa(A); break;
            case 1: await fb(B); break;            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }

   [DataContract]
   public abstract class Union<TA, TB, TC>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly TB B;
      [DataMember] public readonly TC C;
      [DataMember] public readonly int Tag;

      [JsonConstructor]
      private Union(TA a, TB b, TC c)
      {
         A = a;
         B = b;
         C = c;
         Tag = A != null ? 0 : B != null ? 1 : 2;
      }

      protected Union(TA item) { A = item; Tag = 0; }
      protected Union(TB item) { B = item; Tag = 1; }
      protected Union(TC item) { C = item; Tag = 2; }

      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb, Func<TC, T> fc)
      {
         switch (Tag)
         {
            case 0: return fa(A);
            case 1: return fb(B);
            case 2: return fc(C);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb, Func<TC, Task<T>> fc)
      {
         switch (Tag)
         {
            case 0: return await fa(A);
            case 1: return await fb(B);
            case 2: return await fc(C);            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb, Action<TC> fc)
      {
         switch (Tag)
         {
            case 0: fa(A); break;
            case 1: fb(B); break;
            case 2: fc(C); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb, Func<TC, Task> fc)
      {
         switch (Tag)
         {
            case 0: await fa(A); break;
            case 1: await fb(B); break;
            case 2: await fc(C); break;            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }

   [DataContract]
   public abstract class Union<TA, TB, TC, TD>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly TB B;
      [DataMember] public readonly TC C;
      [DataMember] public readonly TD D;
      [DataMember] public readonly int Tag;

      [JsonConstructor]
      private Union(TA a, TB b, TC c, TD d)
      {
         A = a;
         B = b;
         C = c;
         D = d;      
         Tag = A != null ? 0 : B != null ? 1 : C != null ? 2 : 3;
      }

      protected Union(TA item) { A = item; Tag = 0; }
      protected Union(TB item) { B = item; Tag = 1; }
      protected Union(TC item) { C = item; Tag = 2; }
      protected Union(TD item) { D = item; Tag = 3; }
      
      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb, Func<TC, T> fc, Func<TD, T> fd)
      {
         switch (Tag)
         {
            case 0: return fa(A);
            case 1: return fb(B);
            case 2: return fc(C);
            case 3: return fd(D);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb, Func<TC, Task<T>> fc, Func<TD, Task<T>> fd)
      {
         switch (Tag)
         {
            case 0: return await fa(A);
            case 1: return await fb(B);
            case 2: return await fc(C);
            case 3: return await fd(D);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb, Action<TC> fc, Action<TD> fd)
      {
         switch (Tag)
         {
            case 0: fa(A); break;
            case 1: fb(B); break;
            case 2: fc(C); break;
            case 3: fd(D); break;    
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb, Func<TC, Task> fc, Func<TD, Task> fd)
      {
         switch (Tag)
         {
            case 0: await fa(A); break;
            case 1: await fb(B); break;
            case 2: await fc(C); break;
            case 3: await fd(D); break;       
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }

   [DataContract]
   public abstract class Union<TA, TB, TC, TD, TE>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly TB B;
      [DataMember] public readonly TC C;
      [DataMember] public readonly TD D;
      [DataMember] public readonly TE E;
      [DataMember] public readonly int Tag;

      [JsonConstructor]
      private Union(TA a, TB b, TC c, TD d, TE e)
      {
         A = a;
         B = b;
         C = c;
         D = d;
         E = e;
         Tag = A != null ? 0 : B != null ? 1 : C != null ? 2 : D != null ? 3 : 4;
      }

      protected Union(TA item) { A = item; Tag = 0; }
      protected Union(TB item) { B = item; Tag = 1; }
      protected Union(TC item) { C = item; Tag = 2; }
      protected Union(TD item) { D = item; Tag = 3; }
      protected Union(TE item) { E = item; Tag = 4; }

      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb, Func<TC, T> fc, Func<TD, T> fd, Func<TE, T> fe)
      {
         switch (Tag)
         {
            case 0: return fa(A);
            case 1: return fb(B);
            case 2: return fc(C);
            case 3: return fd(D);
            case 4: return fe(E);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb, Func<TC, Task<T>> fc, Func<TD, Task<T>> fd, Func<TE, Task<T>> fe)
      {
         switch (Tag)
         {
            case 0: return await fa(A);
            case 1: return await fb(B);
            case 2: return await fc(C);
            case 3: return await fd(D);
            case 4: return await fe(E);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb, Action<TC> fc, Action<TD> fd, Action<TE> fe)
      {
         switch (Tag)
         {
            case 0: fa(A); break;
            case 1: fb(B); break;
            case 2: fc(C); break;
            case 3: fd(D); break;
            case 4: fe(E); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb, Func<TC, Task> fc, Func<TD, Task> fd, Func<TE, Task> fe)
      {
         switch (Tag)
         {
            case 0: await fa(A); break;
            case 1: await fb(B); break;
            case 2: await fc(C); break;
            case 3: await fd(D); break;
            case 4: await fe(E); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }
}
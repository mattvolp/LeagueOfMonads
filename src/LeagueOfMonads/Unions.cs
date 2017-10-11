using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming
namespace LeagueOfMonads
{
   [DataContract]
   public abstract class Union<TA>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly UnionType Tag;

      protected Union(TA item)
      {
         A = item;
         Tag = UnionType.A;
      }

      public static readonly IEqualityComparer<Union<TA>> Comparer = 
         new UnionEqualityComparer<TA>();

      public enum UnionType { A }

      public T Map<T>(Func<TA, T> fa)
      {
         switch (Tag)
         {
            case UnionType.A: return fa(A);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa)
      {
         switch (Tag)
         {
            case UnionType.A: return await fa(A);            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa)
      {
         switch (Tag)
         {
            case UnionType.A: fa(A); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa)
      {
         switch (Tag)
         {
            case UnionType.A: await fa(A); break;            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }

   [DataContract]
   public abstract class Union<TA, TB>
   {
      [DataMember] public readonly TA A;
      [DataMember] public readonly TB B;
      [DataMember] public readonly UnionType Tag;

      public static readonly IEqualityComparer<Union<TA,TB>> Comparer =
         new UnionEqualityComparer<TA,TB>();

      public enum UnionType { A, B }

      protected Union(TA a, TB b)
      {
         A = a;
         B = b;
         Tag = A != null ? UnionType.A : UnionType.B;
      }

      protected Union(TA item) { A = item; Tag = UnionType.A; }
      protected Union(TB item) { B = item; Tag = UnionType.B; }

      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb)
      {
         switch (Tag)
         {
            case UnionType.A: return fa(A);
            case UnionType.B: return fb(B);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb)
      {
         switch (Tag)
         {
            case UnionType.A: return await fa(A);
            case UnionType.B: return await fb(B);            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb)
      {
         switch (Tag)
         {
            case UnionType.A: fa(A); break;
            case UnionType.B: fb(B); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb)
      {
         switch (Tag)
         {
            case UnionType.A: await fa(A); break;
            case UnionType.B: await fb(B); break;            
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
      [DataMember] public readonly UnionType Tag;

      public static readonly IEqualityComparer<Union<TA,TB,TC>> Comparer =
         new UnionEqualityComparer<TA,TB,TC>();

      public enum UnionType { A, B, C }

      protected Union(TA a, TB b, TC c)
      {
         A = a;
         B = b;
         C = c;
         Tag = A != null 
            ? UnionType.A : B != null 
            ? UnionType.B : UnionType.C;
      }

      protected Union(TA item) { A = item; Tag = UnionType.A; }
      protected Union(TB item) { B = item; Tag = UnionType.B; }
      protected Union(TC item) { C = item; Tag = UnionType.C; }

      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb, Func<TC, T> fc)
      {
         switch (Tag)
         {
            case UnionType.A: return fa(A);
            case UnionType.B: return fb(B);
            case UnionType.C: return fc(C);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb, Func<TC, Task<T>> fc)
      {
         switch (Tag)
         {
            case UnionType.A: return await fa(A);
            case UnionType.B: return await fb(B);
            case UnionType.C: return await fc(C);            
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb, Action<TC> fc)
      {
         switch (Tag)
         {
            case UnionType.A: fa(A); break;
            case UnionType.B: fb(B); break;
            case UnionType.C: fc(C); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb, Func<TC, Task> fc)
      {
         switch (Tag)
         {
            case UnionType.A: await fa(A); break;
            case UnionType.B: await fb(B); break;
            case UnionType.C: await fc(C); break;            
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
      [DataMember] public readonly UnionType Tag;

      public static readonly IEqualityComparer<Union<TA,TB,TC,TD>> Comparer =
         new UnionEqualityComparer<TA,TB,TC,TD>();

      public enum UnionType { A, B, C, D }
      
      protected Union(TA a, TB b, TC c, TD d)
      {
         A = a;
         B = b;
         C = c;
         D = d;      
         Tag = A != null 
            ? UnionType.A : B != null 
            ? UnionType.B : C != null 
            ? UnionType.C : UnionType.D;
      }

      protected Union(TA item) { A = item; Tag = UnionType.A; }
      protected Union(TB item) { B = item; Tag = UnionType.B; }
      protected Union(TC item) { C = item; Tag = UnionType.C; }
      protected Union(TD item) { D = item; Tag = UnionType.D; }
      
      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb, Func<TC, T> fc, Func<TD, T> fd)
      {
         switch (Tag)
         {
            case UnionType.A: return fa(A);
            case UnionType.B: return fb(B);
            case UnionType.C: return fc(C);
            case UnionType.D: return fd(D);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb, Func<TC, Task<T>> fc, Func<TD, Task<T>> fd)
      {
         switch (Tag)
         {
            case UnionType.A: return await fa(A);
            case UnionType.B: return await fb(B);
            case UnionType.C: return await fc(C);
            case UnionType.D: return await fd(D);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb, Action<TC> fc, Action<TD> fd)
      {
         switch (Tag)
         {
            case UnionType.A: fa(A); break;
            case UnionType.B: fb(B); break;
            case UnionType.C: fc(C); break;
            case UnionType.D: fd(D); break;    
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb, Func<TC, Task> fc, Func<TD, Task> fd)
      {
         switch (Tag)
         {
            case UnionType.A: await fa(A); break;
            case UnionType.B: await fb(B); break;
            case UnionType.C: await fc(C); break;
            case UnionType.D: await fd(D); break;       
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
      [DataMember] public readonly UnionType Tag;

      public static readonly IEqualityComparer<Union<TA,TB,TC,TD,TE>> Comparer =
         new UnionEqualityComparer<TA,TB,TC,TD,TE>();

      public enum UnionType { A, B, C, D, E }

      protected Union(TA a, TB b, TC c, TD d, TE e)
      {
         A = a;
         B = b;
         C = c;
         D = d;
         E = e;
         Tag = A != null 
            ? UnionType.A : B != null 
            ? UnionType.B : C != null 
            ? UnionType.C : D != null 
            ? UnionType.D : UnionType.E;
      }

      protected Union(TA item) { A = item; Tag = UnionType.A; }
      protected Union(TB item) { B = item; Tag = UnionType.B; }
      protected Union(TC item) { C = item; Tag = UnionType.C; }
      protected Union(TD item) { D = item; Tag = UnionType.D; }
      protected Union(TE item) { E = item; Tag = UnionType.E; }

      public T Map<T>(Func<TA, T> fa, Func<TB, T> fb, Func<TC, T> fc, Func<TD, T> fd, Func<TE, T> fe)
      {
         switch (Tag)
         {
            case UnionType.A: return fa(A);
            case UnionType.B: return fb(B);
            case UnionType.C: return fc(C);
            case UnionType.D: return fd(D);
            case UnionType.E: return fe(E);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task<T> Map<T>(Func<TA, Task<T>> fa, Func<TB, Task<T>> fb, Func<TC, Task<T>> fc, Func<TD, Task<T>> fd, Func<TE, Task<T>> fe)
      {
         switch (Tag)
         {
            case UnionType.A: return await fa(A);
            case UnionType.B: return await fb(B);
            case UnionType.C: return await fc(C);
            case UnionType.D: return await fd(D);
            case UnionType.E: return await fe(E);
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public void Tee(Action<TA> fa, Action<TB> fb, Action<TC> fc, Action<TD> fd, Action<TE> fe)
      {
         switch (Tag)
         {
            case UnionType.A: fa(A); break;
            case UnionType.B: fb(B); break;
            case UnionType.C: fc(C); break;
            case UnionType.D: fd(D); break;
            case UnionType.E: fe(E); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }

      public async Task Tea(Func<TA, Task> fa, Func<TB, Task> fb, Func<TC, Task> fc, Func<TD, Task> fd, Func<TE, Task> fe)
      {
         switch (Tag)
         {
            case UnionType.A: await fa(A); break;
            case UnionType.B: await fb(B); break;
            case UnionType.C: await fc(C); break;
            case UnionType.D: await fd(D); break;
            case UnionType.E: await fe(E); break;
            default: throw new Exception("Unrecognized tag value: " + Tag);
         }
      }
   }
}
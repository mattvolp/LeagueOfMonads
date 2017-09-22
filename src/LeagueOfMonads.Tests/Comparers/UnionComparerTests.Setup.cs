// ReSharper disable InconsistentNaming
// ReSharper disable MemberCanBePrivate.Local
namespace LeagueOfMonads.Tests.Comparers
{
   public partial class UnionComparerTests
   {
      private class UnionA : Union<int>
      {
         public UnionA(int item) : base(item) { }

         public static implicit operator UnionA(int value)
         {
            return new UnionA(value);
         }
      }

      private class UnionAPrime : Union<int>
      {
         public UnionAPrime(int item) : base(item) { }

         public static implicit operator UnionAPrime(int value)
         {
            return new UnionAPrime(value);
         }
      }

      private class UnionAB : Union<int, B>
      {
         public UnionAB(int item) : base(item) { }

         public UnionAB(B item) : base(item) { }

         public static implicit operator UnionAB(int value)
         {
            return new UnionAB(value);
         }

         public static implicit operator UnionAB(B value)
         {
            return new UnionAB(value);
         }
      }

      private class UnionABPrime : Union<int, B>
      {
         public UnionABPrime(int item) : base(item) { }

         public UnionABPrime(B item) : base(item) { }

         public static implicit operator UnionABPrime(int value)
         {
            return new UnionABPrime(value);
         }

         public static implicit operator UnionABPrime(B value)
         {
            return new UnionABPrime(value);
         }
      }

      private class UnionABC : Union<int, B, C>
      {
         public UnionABC(int item) : base(item) { }
         public UnionABC(B item) : base(item) { }
         public UnionABC(C item) : base(item) { }

         public static implicit operator UnionABC(int value)
         {
            return new UnionABC(value);
         }

         public static implicit operator UnionABC(B value)
         {
            return new UnionABC(value);
         }

         public static implicit operator UnionABC(C value)
         {
            return new UnionABC(value);
         }
      }

      private class UnionABCPrime : Union<int, B, C>
      {
         public UnionABCPrime(int item) : base(item) { }
         public UnionABCPrime(B item) : base(item) { }
         public UnionABCPrime(C item) : base(item) { }

         public static implicit operator UnionABCPrime(int value)
         {
            return new UnionABCPrime(value);
         }

         public static implicit operator UnionABCPrime(B value)
         {
            return new UnionABCPrime(value);
         }

         public static implicit operator UnionABCPrime(C value)
         {
            return new UnionABCPrime(value);
         }
      }

      private class UnionABCD : Union<int, B, C, D>
      {
         public UnionABCD(int item) : base(item) { }
         public UnionABCD(B item) : base(item) { }
         public UnionABCD(C item) : base(item) { }
         public UnionABCD(D item) : base(item) { }

         public static implicit operator UnionABCD(int value)
         {
            return new UnionABCD(value);
         }

         public static implicit operator UnionABCD(B value)
         {
            return new UnionABCD(value);
         }

         public static implicit operator UnionABCD(C value)
         {
            return new UnionABCD(value);
         }

         public static implicit operator UnionABCD(D value)
         {
            return new UnionABCD(value);
         }
      }

      private class UnionABCDPrime : Union<int, B, C, D>
      {
         public UnionABCDPrime(int item) : base(item) { }
         public UnionABCDPrime(B item) : base(item) { }
         public UnionABCDPrime(C item) : base(item) { }
         public UnionABCDPrime(D item) : base(item) { }

         public static implicit operator UnionABCDPrime(int value)
         {
            return new UnionABCDPrime(value);
         }

         public static implicit operator UnionABCDPrime(B value)
         {
            return new UnionABCDPrime(value);
         }

         public static implicit operator UnionABCDPrime(C value)
         {
            return new UnionABCDPrime(value);
         }

         public static implicit operator UnionABCDPrime(D value)
         {
            return new UnionABCDPrime(value);
         }
      }

      private class UnionABCDE : Union<int, B, C, D, E>
      {
         public UnionABCDE(int item) : base(item) { }
         public UnionABCDE(B item) : base(item) { }
         public UnionABCDE(C item) : base(item) { }
         public UnionABCDE(D item) : base(item) { }
         public UnionABCDE(E item) : base(item) { }

         public static implicit operator UnionABCDE(int value)
         {
            return new UnionABCDE(value);
         }

         public static implicit operator UnionABCDE(B value)
         {
            return new UnionABCDE(value);
         }

         public static implicit operator UnionABCDE(C value)
         {
            return new UnionABCDE(value);
         }

         public static implicit operator UnionABCDE(D value)
         {
            return new UnionABCDE(value);
         }

         public static implicit operator UnionABCDE(E value)
         {
            return new UnionABCDE(value);
         }
      }

      private class UnionABCDEPrime : Union<int, B, C, D, E>
      {
         public UnionABCDEPrime(int item) : base(item) { }
         public UnionABCDEPrime(B item) : base(item) { }
         public UnionABCDEPrime(C item) : base(item) { }
         public UnionABCDEPrime(D item) : base(item) { }
         public UnionABCDEPrime(E item) : base(item) { }

         public static implicit operator UnionABCDEPrime(int value)
         {
            return new UnionABCDEPrime(value);
         }

         public static implicit operator UnionABCDEPrime(B value)
         {
            return new UnionABCDEPrime(value);
         }

         public static implicit operator UnionABCDEPrime(C value)
         {
            return new UnionABCDEPrime(value);
         }

         public static implicit operator UnionABCDEPrime(D value)
         {
            return new UnionABCDEPrime(value);
         }

         public static implicit operator UnionABCDEPrime(E value)
         {
            return new UnionABCDEPrime(value);
         }
      }

      private class B { }
      private class C { }
      private class D { }
      private class E { }
   }
}
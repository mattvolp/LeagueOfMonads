using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueOfMonads.Tests.Comparers
{
   [TestClass]
   public partial class UnionComparerTests
   {
      [TestMethod]
      public void ACompare_ReturnsTrueWhenUnderlyingTypeIsEqual()
      {
         var x = new UnionA(1);
         var y = new UnionA(1);
         var sut = UnionA.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ACompare_ReturnsFalseWhenUnderlyingTypeIsNotEqual()
      {
         var x = new UnionA(1);
         var y = new UnionA(2);
         var sut = UnionA.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ACompare_ReturnsTrueWhenDerivedTypeIsDifferent()
      {
         var x = new UnionA(1);
         var y = new UnionAPrime(1);
         var sut = UnionA.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCompare_ReturnsTrueWhenFirstUnderlyingTypeIsEqual()
      {
         var x = new UnionAB(1);
         var y = new UnionAB(1);
         var sut = UnionAB.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCompare_ReturnsFalseWhenFirstUnderlyingTypeIsNotEqual()
      {
         var x = new UnionAB(1);
         var y = new UnionAB(2);
         var sut = UnionAB.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCompare_ReturnsTrueWhenSecondUnderlyingTypeIsEqual()
      {
         var b = new B();
         var x = new UnionAB(b);
         var y = new UnionAB(b);
         var sut = UnionAB.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCompare_ReturnsFalseWhenSecondUnderlyingTypeIsNotEqual()
      {
         var x = new UnionAB(new B());
         var y = new UnionAB(new B());
         var sut = UnionAB.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCompare_ReturnsFalseWhenUnderlyingTypeIsDifferent()
      {
         var x = new UnionAB(1);
         var y = new UnionAB(new B());
         var sut = UnionAB.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCompare_ReturnsTrueWhenDerivedTypeIsDifferent()
      {
         var x = new UnionAB(1);
         var y = new UnionABPrime(1);
         var sut = UnionAB.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsTrueWhenFirstUnderlyingTypeIsEqual()
      {
         var x = new UnionABC(1);
         var y = new UnionABC(1);
         var sut = UnionABC.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsFalseWhenFirstUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABC(1);
         var y = new UnionABC(2);
         var sut = UnionABC.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsTrueWhenSecondUnderlyingTypeIsEqual()
      {
         var b = new B();
         var x = new UnionABC(b);
         var y = new UnionABC(b);
         var sut = UnionABC.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsFalseWhenSecondUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABC(new B());
         var y = new UnionABC(new B());
         var sut = UnionABC.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsTrueWhenThirdUnderlyingTypeIsEqual()
      {
         var c = new C();
         var x = new UnionABC(c);
         var y = new UnionABC(c);
         var sut = UnionABC.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsFalseWhenThirdUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABC(new C());
         var y = new UnionABC(new C());
         var sut = UnionABC.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsFalseWhenUnderlyingTypeIsDifferent()
      {
         var x = new UnionABC(1);
         var y = new UnionABC(new B());
         var sut = UnionABC.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCCompare_ReturnsTrueWhenDerivedTypeIsDifferent()
      {
         var x = new UnionABC(1);
         var y = new UnionABCPrime(1);
         var sut = UnionABC.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsTrueWhenFirstUnderlyingTypeIsEqual()
      {
         var x = new UnionABCD(1);
         var y = new UnionABCD(1);
         var sut = UnionABCD.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsFalseWhenFirstUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCD(1);
         var y = new UnionABCD(2);
         var sut = UnionABCD.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsTrueWhenSecondUnderlyingTypeIsEqual()
      {
         var b = new B();
         var x = new UnionABCD(b);
         var y = new UnionABCD(b);
         var sut = UnionABCD.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsFalseWhenSecondUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCD(new B());
         var y = new UnionABCD(new B());
         var sut = UnionABCD.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsTrueWhenThirdUnderlyingTypeIsEqual()
      {
         var c = new C();
         var x = new UnionABCD(c);
         var y = new UnionABCD(c);
         var sut = UnionABCD.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsFalseWhenThirdUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCD(new C());
         var y = new UnionABCD(new C());
         var sut = UnionABCD.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsTrueWhenFourthUnderlyingTypeIsEqual()
      {
         var d = new D();
         var x = new UnionABCD(d);
         var y = new UnionABCD(d);
         var sut = UnionABCD.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsFalseWhenFourthUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCD(new D());
         var y = new UnionABCD(new D());
         var sut = UnionABCD.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsFalseWhenUnderlyingTypeIsDifferent()
      {
         var x = new UnionABCD(1);
         var y = new UnionABCD(new B());
         var sut = UnionABCD.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDCompare_ReturnsTrueWhenDerivedTypeIsDifferent()
      {
         var x = new UnionABCD(1);
         var y = new UnionABCDPrime(1);
         var sut = UnionABCD.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsTrueWhenFirstUnderlyingTypeIsEqual()
      {
         var x = new UnionABCDE(1);
         var y = new UnionABCDE(1);
         var sut = UnionABCDE.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsFalseWhenFirstUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCDE(1);
         var y = new UnionABCDE(2);
         var sut = UnionABCDE.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsTrueWhenSecondUnderlyingTypeIsEqual()
      {
         var b = new B();
         var x = new UnionABCDE(b);
         var y = new UnionABCDE(b);
         var sut = UnionABCDE.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsFalseWhenSecondUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCDE(new B());
         var y = new UnionABCDE(new B());
         var sut = UnionABCDE.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsTrueWhenThirdUnderlyingTypeIsEqual()
      {
         var c = new C();
         var x = new UnionABCDE(c);
         var y = new UnionABCDE(c);
         var sut = UnionABCDE.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsFalseWhenThirdUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCDE(new C());
         var y = new UnionABCDE(new C());
         var sut = UnionABCDE.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsTrueWhenFourthUnderlyingTypeIsEqual()
      {
         var d = new D();
         var x = new UnionABCDE(d);
         var y = new UnionABCDE(d);
         var sut = UnionABCDE.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsFalseWhenFourthUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCDE(new D());
         var y = new UnionABCDE(new D());
         var sut = UnionABCDE.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsTrueWhenFifthUnderlyingTypeIsEqual()
      {
         var e = new E();
         var x = new UnionABCDE(e);
         var y = new UnionABCDE(e);
         var sut = UnionABCDE.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsFalseWhenFifthUnderlyingTypeIsNotEqual()
      {
         var x = new UnionABCDE(new E());
         var y = new UnionABCDE(new E());
         var sut = UnionABCDE.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsFalseWhenUnderlyingTypeIsDifferent()
      {
         var x = new UnionABCDE(1);
         var y = new UnionABCDE(new B());
         var sut = UnionABCDE.Comparer;

         Assert.IsFalse(sut.Equals(x, y));
      }

      [TestMethod]
      public void ABCDECompare_ReturnsTrueWhenDerivedTypeIsDifferent()
      {
         var x = new UnionABCDE(1);
         var y = new UnionABCDEPrime(1);
         var sut = UnionABCDE.Comparer;

         Assert.IsTrue(sut.Equals(x, y));
      }
   }
}

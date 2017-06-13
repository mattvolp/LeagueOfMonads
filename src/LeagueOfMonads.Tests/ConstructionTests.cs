using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueOfMonads.Tests
{
   [TestClass]
   public class ConstructionTests
   {
      [TestMethod]
      public void IdentityCreateConstructionTest()
      {
         var value = Identity.Create("test");

         Assert.AreEqual("test", value.Value);
      }

      [TestMethod]
      public void OptionSomeConstructionTest()
      {
         var value = Option.Some("test");

         Assert.IsTrue(value.HasValue);
         Assert.AreEqual("test", value.Value);
      }
      
      [TestMethod]
      public void OptionNoneConstructionTest()
      {
         var value = Option.None<string>();

         Assert.IsFalse(value.HasValue);
         Assert.IsNull(value.Value);
      }

      [TestMethod]
      public void OptionNoneValueTypeContstructionTest()
      {
         var value = Option.None<int>();

         Assert.IsFalse(value.HasValue);
         Assert.AreEqual(default(int), value.Value);
      }

      [TestMethod]
      public void OptionCreateSomeConstructionTest()
      {
         var value = Option.Create("test");

         Assert.IsTrue(value.HasValue);
         Assert.AreEqual("test", value.Value);
      }

      [TestMethod]
      public void OptionCreateNoneConstructionTest()
      {
         var value = Option.Create<string>(null);

         Assert.IsFalse(value.HasValue);
         Assert.IsNull(value.Value);
      }

      [TestMethod]
      public void ResultSuccessConstructionTest()
      {
         var value = Result.Success<string, object>("test");

         Assert.IsTrue(value.Successful);
         Assert.AreEqual("test", value.Value);
         Assert.IsNull(value.Failure);
      }

      [TestMethod]
      public void ResultFailureConstructionTest()
      {
         var value = Result.Failure<object, string>("test");

         Assert.IsFalse(value.Successful);
         Assert.IsNull(value.Value);
         Assert.AreEqual("test", value.Failure);
      }

      [TestMethod]
      public void ResultCreateConstructionTest()
      {
         var value = Result.Create<string, object>("test");

         Assert.IsTrue(value.Successful);
         Assert.AreEqual("test", value.Value);
         Assert.IsNull(value.Failure);
      }

      [TestMethod]
      public void ReturnSuccessConstructionTest()
      {
         var value = Return.Success("test");

         Assert.IsTrue(value.Successful);
         Assert.AreEqual("test", value.Value);
         Assert.IsNull(value.Failure);
      }

      [TestMethod]
      public void ReturnFailureExceptionConstructionTest()
      {
         var value = Return.Failure<string>(new Exception("test"));

         Assert.IsFalse(value.Successful);
         Assert.IsNull(value.Value);
         Assert.AreEqual("test", value.Failure.Message);
      }

      [TestMethod]
      public void ReturnFailureStringConstructionTest()
      {
         var value = Return.Failure<string>("test");

         Assert.IsFalse(value.Successful);
         Assert.IsNull(value.Value);
         Assert.AreEqual("test", value.Failure.Message);
      }

      [TestMethod]
      public void ReturnCreateConstructionTest()
      {
         var value = Return.Create("test");

         Assert.IsTrue(value.Successful);
         Assert.AreEqual("test", value.Value);
         Assert.IsNull(value.Failure);
      }
   }
}

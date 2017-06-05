using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueOfMonads.Tests
{
   [TestClass]
   public class ImplicitOperatorTests
   {
      [TestMethod]
      public void IdentityImplicitOperatorTest()
      {
         Identity<string> value = "test";

         Assert.AreEqual("test", value.Value);
      }

      [TestMethod]
      public void OptionSomeImplicitOperatorTest()
      {
         Option<string> value = "test";

         Assert.IsTrue(value.HasValue);
         Assert.AreEqual("test", value.Value);
      }
      
      [TestMethod]
      public void OptionNoneImplicitOperatorTest()
      {
         Option<string> value = (string)null;

         Assert.IsNotNull(value);
         Assert.IsFalse(value.HasValue);
         Assert.IsNull(value.Value);
      }

      [TestMethod]
      public void ResultSuccessImplicitOperatorTest()
      {
         Result<string, object> value = "test";

         Assert.IsTrue(value.Successful);
         Assert.AreEqual("test", value.Value);
         Assert.IsNull(value.Failure);
      }

      [TestMethod]
      public void ResultFailureImplicitOperatorTest()
      {
         Result<object, string> value = "test";

         Assert.IsFalse(value.Successful);
         Assert.IsNull(value.Value);
         Assert.AreEqual("test", value.Failure);
      }

      [TestMethod]
      public void ReturnSuccessImplicitOperatorTest()
      {
         Return<string> value = "test";

         Assert.IsTrue(value.Successful);
         Assert.AreEqual("test", value.Value);
         Assert.IsNull(value.Failure);
      }

      [TestMethod]
      public void ReturnFailureImplicitOperatorTest()
      {
         Return<string> value = new Exception("test");

         Assert.IsFalse(value.Successful);
         Assert.IsNull(value.Value);
         Assert.AreEqual("test", value.Failure.Message);
      }
   }
}

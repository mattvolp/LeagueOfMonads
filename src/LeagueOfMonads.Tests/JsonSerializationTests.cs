using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeagueOfMonads.Tests
{
   [TestClass]
   public class JsonSerializationTests
   {
      [TestMethod]
      public void OptionSomeSerializationTest()
      {
         var expected = Option.Create("test");
         var actual = JsonConvert.DeserializeObject<Option<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsTrue(actual.HasValue);
         Assert.AreEqual("test", actual.Value);
      }

      [TestMethod]
      public void OptionNoneSerializationTest()
      {
         var expected = Option.None<string>();
         var actual = JsonConvert.DeserializeObject<Option<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsFalse(actual.HasValue);
         Assert.IsNull(actual.Value);
      }

      [TestMethod]
      public void IdentitySerializationTest()
      {
         var expected = Identity.Create("test");
         var actual = JsonConvert.DeserializeObject<Identity<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.AreEqual("test", actual.Value);
      }

      [TestMethod]
      public void ResultSuccessSerializationTest()
      {
         var expected = Result.Success<string, string>("test");
         var actual = JsonConvert.DeserializeObject<Result<string, string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsTrue(actual.Successful);
         Assert.AreEqual("test", actual.Value);
         Assert.IsNull(actual.Failure);
      }

      [TestMethod]
      public void ResultFailureSerializationTest()
      {
         var expected = Result.Failure<string, string>("test");
         var actual = JsonConvert.DeserializeObject<Result<string, string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsFalse(actual.Successful);
         Assert.AreEqual("test", actual.Failure);
         Assert.IsNull(actual.Value);
      }

      [TestMethod]
      public void ReturnSuccessSerializationTest()
      {
         var expected = Return.Success("test");
         var actual = JsonConvert.DeserializeObject<Return<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsTrue(actual.Successful);
         Assert.AreEqual("test", actual.Value);
         Assert.IsNull(actual.Failure);
      }

      [TestMethod]
      public void ReturnFailureSerialziationTest()
      {
         var expected = Return.Failure<string>(new Exception("test"));
         var actual = JsonConvert.DeserializeObject<Return<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsFalse(actual.Successful);
         Assert.AreEqual("test", actual.Failure.Message);
         Assert.IsNull(actual.Value);
      }
   }
}

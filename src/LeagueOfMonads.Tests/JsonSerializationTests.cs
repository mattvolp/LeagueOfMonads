using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace LeagueOfMonads.Tests
{
   [TestClass]
   public class JsonSerializationTests
   {
      [TestMethod]
      public void OptionSerializationTest()
      {
         var expected = Option.Create("test");
         var actual = JsonConvert.DeserializeObject<Option<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsTrue(actual.HasValue);
         Assert.AreEqual("test", actual.Value);
      }

      [TestMethod]
      public void DataSerializationTest()
      {
         var expected = Data.Create("test");
         var actual = JsonConvert.DeserializeObject<Option<string>>(
            JsonConvert.SerializeObject(expected));

         Assert.IsTrue(actual.HasValue);
         Assert.AreEqual("test", actual.Value);
      }
   }
}

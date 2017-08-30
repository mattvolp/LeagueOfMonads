using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueOfMonads.Tests
{
   [TestClass]
   public class OptionsExTests
   {
      [TestMethod]
      public void ToNullableWorksWithValue()
      {
         var option = Option.Some(1);
         var actual = option.ToNullable();

         Assert.AreEqual(1, actual);
      }

      [TestMethod]
      public void ToNullableWorksWithoutValue()
      {
         var option = Option.None<int>();
         var actual = option.ToNullable();

         Assert.IsNull(actual);
      }
   }
}

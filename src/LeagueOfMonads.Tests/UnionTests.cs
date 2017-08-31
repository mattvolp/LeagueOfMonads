using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueOfMonads.Tests
{
   [TestClass]
   public class UnionTests
   {
      [TestMethod]
      public void X()
      {
         var u = new TestUnion(3);
         var a = u.Map(i => i.ToString(), s => s);

         Assert.AreEqual("3", a);
      }

      private class TestUnion
         : Union<int, string>
      {
         public TestUnion(int item) 
            : base(item)
         {
         }

         public TestUnion(string item) 
            : base(item)
         {
         }
      }
   }   
}

using System;
using System.Threading.Tasks;
using LeagueOfMonads.NoLambda;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LeagueOfMonads.Tests.NoLambda
{
   [TestClass]
   public class TaskExt
   {
      [TestMethod]
      public async Task TestTee1()
      {
         var output = "";

         void TestMethod(string input, string extra1)
         {
            output = input + extra1;
         }

         await Task.FromResult("test")
            .Tee(TestMethod, "e1");

         Assert.AreEqual("teste1", output);
      }

      [TestMethod]
      public async Task TestTee2()
      {
         var output = "";

         void TestMethod(string input, string extra1, string extra2)
         {
            output = input + extra1 + extra2;
         }

         await Task.FromResult("test")
            .Tee(TestMethod, "e1", "e2");

         Assert.AreEqual("teste1e2", output);
      }

      [TestMethod]
      public async Task TestTee3()
      {
         var output = "";

         void TestMethod(string input, string extra1, string extra2, string extra3)
         {
            output = input + extra1 + extra2 + extra3;
         }

         await Task.FromResult("test")
            .Tee(TestMethod, "e1", "e2", "e3");

         Assert.AreEqual("teste1e2e3", output);
      }

      [TestMethod]
      public async Task TestTea1()
      {
         var output = "";

         async Task TestMethod(string input, string extra1)
         {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            output = input + extra1;
         }

         await Task.FromResult("test")
            .Tea(TestMethod, "e1");

         Assert.AreEqual("teste1", output);
      }

      [TestMethod]
      public async Task TestTea2()
      {
         var output = "";

         async Task TestMethod(string input, string extra1, string extra2)
         {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            output = input + extra1 + extra2;
         }

         await Task.FromResult("test")
            .Tea(TestMethod, "e1", "e2");

         Assert.AreEqual("teste1e2", output);
      }

      [TestMethod]
      public async Task TestTea3()
      {
         var output = "";

         async Task TestMethod(string input, string extra1, string extra2, string extra3)
         {
            await Task.Delay(TimeSpan.FromMilliseconds(100));
            output = input + extra1 + extra2 + extra3;
         }

         await Task.FromResult("test")
            .Tea(TestMethod, "e1", "e2", "e3");

         Assert.AreEqual("teste1e2e3", output);
      }
   }
}

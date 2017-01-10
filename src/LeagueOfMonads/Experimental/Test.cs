#if EXPERIMENTAL

using LeagueOfMonads.NoLambda;
using System.Threading.Tasks;

namespace LeagueOfMonads.Experimental
{
   internal class Test
   {
      public async Task X()
      {
         var d = Data.Create(3)
            .Map(Y, false);
      }

      private static string Y(int i, bool b)
      {
         return i.ToString();
      }
   }
}

#endif
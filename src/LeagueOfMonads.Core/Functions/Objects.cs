using System.Linq;

namespace LeagueOfMonads.Functions
{
   public static class Objects
   {
      public static int GetHashCode(object o)
      {
         return o.GetHashCode();
      }

      public static int GetMultiFieldHashCode(params object[] objects)
      {
         return objects.Aggregate(17, ApplyToHash);
      }

      private static int ApplyToHash(int seed, object obj)
      {
         unchecked
         {
            return seed * 31 + obj.GetHashCode();
         }
      }
   }
}
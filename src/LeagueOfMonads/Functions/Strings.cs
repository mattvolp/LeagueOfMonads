using System.Collections.Generic;

namespace LeagueOfMonads.Functions
{
   public static class Strings
   {
      public static IEnumerable<string> Split(string value, int parts)
      {
         var l = value.Length / parts;

         if (l < 1) l = 1;

         var s = l * -1;

         for (var i = 0; i < parts; i++)
            if (i < parts - 1)
               yield return Substring(value, s += l, l);
            else
               yield return Substring(value, s += l, value.Length);
      }

      public static string Substring(string value, int index, int length)
      {
         return index > (value.Length - 1)
            ? ""
            : index + length > (value.Length)
               ? value.Substring(index, value.Length - index)
               : value.Substring(index, length);
      }
   }
}
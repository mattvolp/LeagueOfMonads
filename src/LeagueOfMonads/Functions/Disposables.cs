using System;

namespace LeagueOfMonads.Functions
{
   public static class Disposables
   {
      public static class Disposable
      {
         public static void Dispose(IDisposable disposable)
         {
            disposable.Dispose();
         }
      }
   }
}

using System;

namespace LeagueOfMonads.Functions
{
   public static class Disposables
   {
      public static void Dispose(IDisposable disposable)
      {
         disposable.Dispose();
      }
   }
}

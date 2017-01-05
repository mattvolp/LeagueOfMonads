#if EXPERIMENTAL

namespace LeagueOfMonads.Experimental
{
   // have before and after functions?  for logging maybe / tracing?
   public class Trace<T>
      : Data<T>
   {
      public Trace(T value) 
         : base(value)
      {
      }
   }
}

#endif
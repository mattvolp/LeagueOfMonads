using System;
using System.Collections.Generic;
using LeagueOfMonads.Functions;

namespace LeagueOfMonads.Comparers
{
   public class UnionEqualityComparer<TA> : IEqualityComparer<Union<TA>>
   {
      public bool Equals(Union<TA> x, Union<TA> y)
      {
         return ReferenceEquals(x, y)
                || x != null
                && y != null
                && x.A.Equals(y.A);
      }

      public int GetHashCode(Union<TA> obj)
      {
         return obj.A.GetHashCode();
      }
   }

   public class UnionEqualityComparer<TA, TB> : IEqualityComparer<Union<TA, TB>>
   {
      public bool Equals(Union<TA, TB> x, Union<TA, TB> y)
      {
         return ReferenceEquals(x, y)
                || x != null
                && y != null
                && x.Tag == y.Tag
                && (x.Tag == Union<TA, TB>.UnionType.A && x.A.Equals(y.A)
                    || x.Tag == Union<TA, TB>.UnionType.B && x.B.Equals(y.B));
      }

      public int GetHashCode(Union<TA, TB> obj)
      {
         return Objects
            .GetMultiFieldHashCode(
               obj.Tag,
               obj.Tag == Union<TA, TB>.UnionType.A
                  ? obj.A.GetHashCode()
                  : obj.B.GetHashCode());
      }
   }

   public class UnionEqualityComparer<TA, TB, TC> : IEqualityComparer<Union<TA, TB, TC>>
   {
      public bool Equals(Union<TA, TB, TC> x, Union<TA, TB, TC> y)
      {
         return ReferenceEquals(x, y)
                || x != null
                && y != null
                && x.Tag == y.Tag
                && (x.Tag == Union<TA, TB, TC>.UnionType.A && x.A.Equals(y.A)
                    || x.Tag == Union<TA, TB, TC>.UnionType.B && x.B.Equals(y.B)
                    || x.Tag == Union<TA, TB, TC>.UnionType.C && x.C.Equals(y.C));
      }

      public int GetHashCode(Union<TA, TB, TC> obj)
      {
         return Objects
            .GetMultiFieldHashCode(
               obj.Tag,
               GetBaseHashCode(obj));
      }

      private static int GetBaseHashCode(Union<TA, TB, TC> obj)
      {
         switch (obj.Tag)
         {
            case Union<TA, TB, TC>.UnionType.A:
               return obj.A.GetHashCode();
            case Union<TA, TB, TC>.UnionType.B:
               return obj.B.GetHashCode();
            case Union<TA, TB, TC>.UnionType.C:
               return obj.C.GetHashCode();
            default:
               throw new ArgumentOutOfRangeException();
         }
      }
   }

   public class UnionEqualityComparer<TA, TB, TC, TD> : IEqualityComparer<Union<TA, TB, TC, TD>>
   {
      public bool Equals(Union<TA, TB, TC, TD> x, Union<TA, TB, TC, TD> y)
      {
         return ReferenceEquals(x, y)
                || x != null
                && y != null
                && x.Tag == y.Tag
                && (x.Tag == Union<TA, TB, TC, TD>.UnionType.A && x.A.Equals(y.A)
                    || x.Tag == Union<TA, TB, TC, TD>.UnionType.B && x.B.Equals(y.B)
                    || x.Tag == Union<TA, TB, TC, TD>.UnionType.C && x.C.Equals(y.C)
                    || x.Tag == Union<TA, TB, TC, TD>.UnionType.D && x.D.Equals(y.D));
      }

      public int GetHashCode(Union<TA, TB, TC, TD> obj)
      {
         return Objects
            .GetMultiFieldHashCode(
               obj.Tag,
               GetBaseHashCode(obj));
      }

      private static int GetBaseHashCode(Union<TA, TB, TC, TD> obj)
      {
         switch (obj.Tag)
         {
            case Union<TA, TB, TC, TD>.UnionType.A:
               return obj.A.GetHashCode();
            case Union<TA, TB, TC, TD>.UnionType.B:
               return obj.B.GetHashCode();
            case Union<TA, TB, TC, TD>.UnionType.C:
               return obj.C.GetHashCode();
            case Union<TA, TB, TC, TD>.UnionType.D:
               return obj.D.GetHashCode();
            default:
               throw new ArgumentOutOfRangeException();
         }
      }
   }

   public class UnionEqualityComparer<TA, TB, TC, TD, TE> : IEqualityComparer<Union<TA, TB, TC, TD, TE>>
   {
      public bool Equals(Union<TA, TB, TC, TD, TE> x, Union<TA, TB, TC, TD, TE> y)
      {
         return ReferenceEquals(x, y)
                || x != null
                && y != null
                && x.Tag == y.Tag
                && (x.Tag == Union<TA, TB, TC, TD, TE>.UnionType.A && x.A.Equals(y.A)
                    || x.Tag == Union<TA, TB, TC, TD, TE>.UnionType.B && x.B.Equals(y.B)
                    || x.Tag == Union<TA, TB, TC, TD, TE>.UnionType.C && x.C.Equals(y.C)
                    || x.Tag == Union<TA, TB, TC, TD, TE>.UnionType.D && x.D.Equals(y.D)
                    || x.Tag == Union<TA, TB, TC, TD, TE>.UnionType.E && x.E.Equals(y.E));
      }

      public int GetHashCode(Union<TA, TB, TC, TD, TE> obj)
      {
         return Objects
            .GetMultiFieldHashCode(
               obj.Tag,
               GetBaseHashCode(obj));
      }

      private static int GetBaseHashCode(Union<TA, TB, TC, TD, TE> obj)
      {
         switch (obj.Tag)
         {
            case Union<TA, TB, TC, TD, TE>.UnionType.A:
               return obj.A.GetHashCode();
            case Union<TA, TB, TC, TD, TE>.UnionType.B:
               return obj.B.GetHashCode();
            case Union<TA, TB, TC, TD, TE>.UnionType.C:
               return obj.C.GetHashCode();
            case Union<TA, TB, TC, TD, TE>.UnionType.D:
               return obj.D.GetHashCode();
            case Union<TA, TB, TC, TD, TE>.UnionType.E:
               return obj.E.GetHashCode();
            default:
               throw new ArgumentOutOfRangeException();
         }
      }
   }
}
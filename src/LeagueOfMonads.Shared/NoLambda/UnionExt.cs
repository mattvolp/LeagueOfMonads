using System;
using System.Threading.Tasks;

// ReSharper disable InconsistentNaming

namespace LeagueOfMonads.NoLambda
{
   public static class UnionExt
   {
      public static TResult Map<TA, A, TResult>(
         this Union<TA> m,
         Func<TA, A, TResult> f,
         A a)
      {
         return m.Map(t => f(t, a));
      }

      public static TResult Map<TA, A, B, TResult>(
         this Union<TA> m,
         Func<TA, A, B, TResult> f,
         A a,
         B b)
      {
         return m.Map(t => f(t, a, b));
      }

      public static TResult Map<TA, A, B, C, TResult>(
         this Union<TA> m,
         Func<TA, A, B, C, TResult> f,
         A a,
         B b,
         C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      public static TResult Map<TA, TB, A, TResult>(
         this Union<TA, TB> m,
         Func<TA, A, TResult> fa,
         Func<TB, A, TResult> fb,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a));
      }

      public static TResult Map<TA, TB, A, B, TResult>(
         this Union<TA, TB> m,
         Func<TA, A, B, TResult> fa,
         Func<TB, A, B, TResult> fb,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b));
      }

      public static TResult Map<TA, TB, A, B, C, TResult>(
         this Union<TA, TB> m,
         Func<TA, A, B, C, TResult> fa,
         Func<TB, A, B, C, TResult> fb,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c));
      }

      public static TResult Map<TA, TB, TC, A, TResult>(
         this Union<TA, TB, TC> m,
         Func<TA, A, TResult> fa,
         Func<TB, A, TResult> fb,
         Func<TC, A, TResult> fc,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a));
      }

      public static TResult Map<TA, TB, TC, A, B, TResult>(
         this Union<TA, TB, TC> m,
         Func<TA, A, B, TResult> fa,
         Func<TB, A, B, TResult> fb,
         Func<TC, A, B, TResult> fc,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b));
      }

      public static TResult Map<TA, TB, TC, A, B, C, TResult>(
         this Union<TA, TB, TC> m,
         Func<TA, A, B, C, TResult> fa,
         Func<TB, A, B, C, TResult> fb,
         Func<TC, A, B, C, TResult> fc,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c));
      }

      public static TResult Map<TA, TB, TC, TD, A, TResult>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, TResult> fa,
         Func<TB, A, TResult> fb,
         Func<TC, A, TResult> fc,
         Func<TD, A, TResult> fd,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a));
      }

      public static TResult Map<TA, TB, TC, TD, A, B, TResult>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, B, TResult> fa,
         Func<TB, A, B, TResult> fb,
         Func<TC, A, B, TResult> fc,
         Func<TD, A, B, TResult> fd,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b));
      }

      public static TResult Map<TA, TB, TC, TD, A, B, C, TResult>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, B, C, TResult> fa,
         Func<TB, A, B, C, TResult> fb,
         Func<TC, A, B, C, TResult> fc,
         Func<TD, A, B, C, TResult> fd,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c));
      }


      public static TResult Map<TA, TB, TC, TD, TE, A, TResult>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, TResult> fa,
         Func<TB, A, TResult> fb,
         Func<TC, A, TResult> fc,
         Func<TD, A, TResult> fd,
         Func<TE, A, TResult> fe,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a),
            t => fe(t, a));
      }

      public static TResult Map<TA, TB, TC, TD, TE, A, B, TResult>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, B, TResult> fa,
         Func<TB, A, B, TResult> fb,
         Func<TC, A, B, TResult> fc,
         Func<TD, A, B, TResult> fd,
         Func<TE, A, B, TResult> fe,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b),
            t => fe(t, a, b));
      }

      public static TResult Map<TA, TB, TC, TD, TE, A, B, C, TResult>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, B, C, TResult> fa,
         Func<TB, A, B, C, TResult> fb,
         Func<TC, A, B, C, TResult> fc,
         Func<TD, A, B, C, TResult> fd,
         Func<TE, A, B, C, TResult> fe,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c),
            t => fe(t, a, b, c));
      }

















      public static Task<TResult> Map<TA, A, TResult>(
         this Union<TA> m,
         Func<TA, A, Task<TResult>> f,
         A a)
      {
         return m.Map(t => f(t, a));
      }

      public static Task<TResult> Map<TA, A, B, TResult>(
         this Union<TA> m,
         Func<TA, A, B, Task<TResult>> f,
         A a,
         B b)
      {
         return m.Map(t => f(t, a, b));
      }

      public static Task<TResult> Map<TA, A, B, C, TResult>(
         this Union<TA> m,
         Func<TA, A, B, C, Task<TResult>> f,
         A a,
         B b,
         C c)
      {
         return m.Map(t => f(t, a, b, c));
      }

      public static Task<TResult> Map<TA, TB, A, TResult>(
         this Union<TA, TB> m,
         Func<TA, A, Task<TResult>> fa,
         Func<TB, A, Task<TResult>> fb,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a));
      }

      public static Task<TResult> Map<TA, TB, A, B, TResult>(
         this Union<TA, TB> m,
         Func<TA, A, B, Task<TResult>> fa,
         Func<TB, A, B, Task<TResult>> fb,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b));
      }

      public static Task<TResult> Map<TA, TB, A, B, C, TResult>(
         this Union<TA, TB> m,
         Func<TA, A, B, C, Task<TResult>> fa,
         Func<TB, A, B, C, Task<TResult>> fb,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c));
      }

      public static Task<TResult> Map<TA, TB, TC, A, TResult>(
         this Union<TA, TB, TC> m,
         Func<TA, A, Task<TResult>> fa,
         Func<TB, A, Task<TResult>> fb,
         Func<TC, A, Task<TResult>> fc,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a));
      }

      public static Task<TResult> Map<TA, TB, TC, A, B, TResult>(
         this Union<TA, TB, TC> m,
         Func<TA, A, B, Task<TResult>> fa,
         Func<TB, A, B, Task<TResult>> fb,
         Func<TC, A, B, Task<TResult>> fc,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b));
      }

      public static Task<TResult> Map<TA, TB, TC, A, B, C, TResult>(
         this Union<TA, TB, TC> m,
         Func<TA, A, B, C, Task<TResult>> fa,
         Func<TB, A, B, C, Task<TResult>> fb,
         Func<TC, A, B, C, Task<TResult>> fc,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c));
      }

      public static Task<TResult> Map<TA, TB, TC, TD, A, TResult>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, Task<TResult>> fa,
         Func<TB, A, Task<TResult>> fb,
         Func<TC, A, Task<TResult>> fc,
         Func<TD, A, Task<TResult>> fd,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a));
      }

      public static Task<TResult> Map<TA, TB, TC, TD, A, B, TResult>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, B, Task<TResult>> fa,
         Func<TB, A, B, Task<TResult>> fb,
         Func<TC, A, B, Task<TResult>> fc,
         Func<TD, A, B, Task<TResult>> fd,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b));
      }

      public static Task<TResult> Map<TA, TB, TC, TD, A, B, C, TResult>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, B, C, Task<TResult>> fa,
         Func<TB, A, B, C, Task<TResult>> fb,
         Func<TC, A, B, C, Task<TResult>> fc,
         Func<TD, A, B, C, Task<TResult>> fd,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c));
      }


      public static Task<TResult> Map<TA, TB, TC, TD, TE, A, TResult>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, Task<TResult>> fa,
         Func<TB, A, Task<TResult>> fb,
         Func<TC, A, Task<TResult>> fc,
         Func<TD, A, Task<TResult>> fd,
         Func<TE, A, Task<TResult>> fe,
         A a)
      {
         return m.Map(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a),
            t => fe(t, a));
      }

      public static Task<TResult> Map<TA, TB, TC, TD, TE, A, B, TResult>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, B, Task<TResult>> fa,
         Func<TB, A, B, Task<TResult>> fb,
         Func<TC, A, B, Task<TResult>> fc,
         Func<TD, A, B, Task<TResult>> fd,
         Func<TE, A, B, Task<TResult>> fe,
         A a,
         B b)
      {
         return m.Map(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b),
            t => fe(t, a, b));
      }

      public static Task<TResult> Map<TA, TB, TC, TD, TE, A, B, C, TResult>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, B, C, Task<TResult>> fa,
         Func<TB, A, B, C, Task<TResult>> fb,
         Func<TC, A, B, C, Task<TResult>> fc,
         Func<TD, A, B, C, Task<TResult>> fd,
         Func<TE, A, B, C, Task<TResult>> fe,
         A a,
         B b,
         C c)
      {
         return m.Map(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c),
            t => fe(t, a, b, c));
      }

      public static Union<TA> Tee<TA, A>(
         this Union<TA> m,
         Action<TA, A> f,
         A a)
      {
         return m.Tee(
            t => f(t, a));
      }

      public static Union<TA> Tee<TA, A, B>(
         this Union<TA> m,
         Action<TA, A, B> f,
         A a,
         B b)
      {
         return m.Tee(
            t => f(t, a, b));
      }


      public static Union<TA> Tee<TA, A, B, C>(
         this Union<TA> m,
         Action<TA, A, B, C> f,
         A a,
         B b,
         C c)
      {
         return m.Tee(
            t => f(t, a, b, c));
      }

      public static Union<TA, TB> Tee<TA, TB, A>(
         this Union<TA, TB> m,
         Action<TA, A> fa,
         Action<TB, A> fb,
         A a)
      {
         return m.Tee(
            t => fa(t, a),
            t => fb(t, a));
      }

      public static Union<TA, TB> Tee<TA, TB, A, B>(
         this Union<TA, TB> m,
         Action<TA, A, B> fa,
         Action<TB, A, B> fb,
         A a,
         B b)
      {
         return m.Tee(
            t => fa(t, a, b),
            t => fb(t, a, b));
      }


      public static Union<TA, TB> Tee<TA, TB, A, B, C>(
         this Union<TA, TB> m,
         Action<TA, A, B, C> fa,
         Action<TB, A, B, C> fb,
         A a,
         B b,
         C c)
      {
         return m.Tee(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c));
      }

      public static Union<TA, TB, TC> Tee<TA, TB, TC, A>(
         this Union<TA, TB, TC> m,
         Action<TA, A> fa,
         Action<TB, A> fb,
         Action<TC, A> fc,
         A a)
      {
         return m.Tee(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a));
      }

      public static Union<TA, TB, TC> Tee<TA, TB, TC, A, B>(
         this Union<TA, TB, TC> m,
         Action<TA, A, B> fa,
         Action<TB, A, B> fb,
         Action<TC, A, B> fc,
         A a,
         B b)
      {
         return m.Tee(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b));
      }


      public static Union<TA, TB, TC> Tee<TA, TB, TC, A, B, C>(
         this Union<TA, TB, TC> m,
         Action<TA, A, B, C> fa,
         Action<TB, A, B, C> fb,
         Action<TC, A, B, C> fc,
         A a,
         B b,
         C c)
      {
         return m.Tee(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c));
      }

      public static Union<TA, TB, TC, TD> Tee<TA, TB, TC, TD, A>(
         this Union<TA, TB, TC, TD> m,
         Action<TA, A> fa,
         Action<TB, A> fb,
         Action<TC, A> fc,
         Action<TD, A> fd,
         A a)
      {
         return m.Tee(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a));
      }

      public static Union<TA, TB, TC, TD> Tee<TA, TB, TC, TD, A, B>(
         this Union<TA, TB, TC, TD> m,
         Action<TA, A, B> fa,
         Action<TB, A, B> fb,
         Action<TC, A, B> fc,
         Action<TD, A, B> fd,
         A a,
         B b)
      {
         return m.Tee(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b));
      }


      public static Union<TA, TB, TC, TD> Tee<TA, TB, TC, TD, A, B, C>(
         this Union<TA, TB, TC, TD> m,
         Action<TA, A, B, C> fa,
         Action<TB, A, B, C> fb,
         Action<TC, A, B, C> fc,
         Action<TD, A, B, C> fd,
         A a,
         B b,
         C c)
      {
         return m.Tee(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c));
      }

      public static Union<TA, TB, TC, TD, TE> Tee<TA, TB, TC, TD, TE, A>(
         this Union<TA, TB, TC, TD, TE> m,
         Action<TA, A> fa,
         Action<TB, A> fb,
         Action<TC, A> fc,
         Action<TD, A> fd,
         Action<TE, A> fe,
         A a)
      {
         return m.Tee(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a),
            t => fe(t, a));
      }

      public static Union<TA, TB, TC, TD, TE> Tee<TA, TB, TC, TD, TE, A, B>(
         this Union<TA, TB, TC, TD, TE> m,
         Action<TA, A, B> fa,
         Action<TB, A, B> fb,
         Action<TC, A, B> fc,
         Action<TD, A, B> fd,
         Action<TE, A, B> fe,
         A a,
         B b)
      {
         return m.Tee(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b),
            t => fe(t, a, b));
      }


      public static Union<TA, TB, TC, TD, TE> Tee<TA, TB, TC, TD, TE, A, B, C>(
         this Union<TA, TB, TC, TD, TE> m,
         Action<TA, A, B, C> fa,
         Action<TB, A, B, C> fb,
         Action<TC, A, B, C> fc,
         Action<TD, A, B, C> fd,
         Action<TE, A, B, C> fe,
         A a,
         B b,
         C c)
      {
         return m.Tee(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c),
            t => fe(t, a, b, c));
      }

      public static async Task<Union<TA>> Tea<TA, A>(
         this Union<TA> m,
         Func<TA, A, Task> f,
         A a)
      {
         return await m.Tea(
            t => f(t, a));
      }

      public static async Task<Union<TA>> Tea<TA, A, B>(
         this Union<TA> m,
         Func<TA, A, B, Task> f,
         A a,
         B b)
      {
         return await m.Tea(
            t => f(t, a, b));
      }


      public static async Task<Union<TA>> Tea<TA, A, B, C>(
         this Union<TA> m,
         Func<TA, A, B, C, Task> f,
         A a,
         B b,
         C c)
      {
         return await m.Tea(
            t => f(t, a, b, c));
      }

      public static async Task<Union<TA, TB>> Tea<TA, TB, A>(
         this Union<TA, TB> m,
         Func<TA, A, Task> fa,
         Func<TB, A, Task> fb,
         A a)
      {
         return await m.Tea(
            t => fa(t, a),
            t => fb(t, a));
      }

      public static async Task<Union<TA, TB>> Tea<TA, TB, A, B>(
         this Union<TA, TB> m,
         Func<TA, A, B, Task> fa,
         Func<TB, A, B, Task> fb,
         A a,
         B b)
      {
         return await m.Tea(
            t => fa(t, a, b),
            t => fb(t, a, b));
      }


      public static async Task<Union<TA, TB>> Tea<TA, TB, A, B, C>(
         this Union<TA, TB> m,
         Func<TA, A, B, C, Task> fa,
         Func<TB, A, B, C, Task> fb,
         A a,
         B b,
         C c)
      {
         return await m.Tea(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c));
      }

      public static async Task<Union<TA, TB, TC>> Tea<TA, TB, TC, A>(
         this Union<TA, TB, TC> m,
         Func<TA, A, Task> fa,
         Func<TB, A, Task> fb,
         Func<TC, A, Task> fc,
         A a)
      {
         return await m.Tea(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a));
      }

      public static async Task<Union<TA, TB, TC>> Tea<TA, TB, TC, A, B>(
         this Union<TA, TB, TC> m,
         Func<TA, A, B, Task> fa,
         Func<TB, A, B, Task> fb,
         Func<TC, A, B, Task> fc,
         A a,
         B b)
      {
         return await m.Tea(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b));
      }


      public static async Task<Union<TA, TB, TC>> Tea<TA, TB, TC, A, B, C>(
         this Union<TA, TB, TC> m,
         Func<TA, A, B, C, Task> fa,
         Func<TB, A, B, C, Task> fb,
         Func<TC, A, B, C, Task> fc,
         A a,
         B b,
         C c)
      {
         return await m.Tea(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c));
      }

      public static async Task<Union<TA, TB, TC, TD>> Tea<TA, TB, TC, TD, A>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, Task> fa,
         Func<TB, A, Task> fb,
         Func<TC, A, Task> fc,
         Func<TD, A, Task> fd,
         A a)
      {
         return await m.Tea(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a));
      }

      public static async Task<Union<TA, TB, TC, TD>> Tea<TA, TB, TC, TD, A, B>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, B, Task> fa,
         Func<TB, A, B, Task> fb,
         Func<TC, A, B, Task> fc,
         Func<TD, A, B, Task> fd,
         A a,
         B b)
      {
         return await m.Tea(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b));
      }


      public static async Task<Union<TA, TB, TC, TD>> Tea<TA, TB, TC, TD, A, B, C>(
         this Union<TA, TB, TC, TD> m,
         Func<TA, A, B, C, Task> fa,
         Func<TB, A, B, C, Task> fb,
         Func<TC, A, B, C, Task> fc,
         Func<TD, A, B, C, Task> fd,
         A a,
         B b,
         C c)
      {
         return await m.Tea(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c));
      }

      public static async Task<Union<TA, TB, TC, TD, TE>> Tea<TA, TB, TC, TD, TE, A>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, Task> fa,
         Func<TB, A, Task> fb,
         Func<TC, A, Task> fc,
         Func<TD, A, Task> fd,
         Func<TE, A, Task> fe,
         A a)
      {
         return await m.Tea(
            t => fa(t, a),
            t => fb(t, a),
            t => fc(t, a),
            t => fd(t, a),
            t => fe(t, a));
      }

      public static async Task<Union<TA, TB, TC, TD, TE>> Tea<TA, TB, TC, TD, TE, A, B>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, B, Task> fa,
         Func<TB, A, B, Task> fb,
         Func<TC, A, B, Task> fc,
         Func<TD, A, B, Task> fd,
         Func<TE, A, B, Task> fe,
         A a,
         B b)
      {
         return await m.Tea(
            t => fa(t, a, b),
            t => fb(t, a, b),
            t => fc(t, a, b),
            t => fd(t, a, b),
            t => fe(t, a, b));
      }


      public static async Task<Union<TA, TB, TC, TD, TE>> Tea<TA, TB, TC, TD, TE, A, B, C>(
         this Union<TA, TB, TC, TD, TE> m,
         Func<TA, A, B, C, Task> fa,
         Func<TB, A, B, C, Task> fb,
         Func<TC, A, B, C, Task> fc,
         Func<TD, A, B, C, Task> fd,
         Func<TE, A, B, C, Task> fe,
         A a,
         B b,
         C c)
      {
         return await m.Tea(
            t => fa(t, a, b, c),
            t => fb(t, a, b, c),
            t => fc(t, a, b, c),
            t => fd(t, a, b, c),
            t => fe(t, a, b, c));
      }
   }
}

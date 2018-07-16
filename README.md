# League Of Monads

A gathering place for things that identify as monads but are C# in orientation

| AppVeyor | GitLab | GitLab |
| --- | --- | --- |
| <img src="https://ci.appveyor.com/api/projects/status/32r7s2skrgm9ubva?svg=true" alt="Project Badge"> | [![pipeline status](https://gitlab.com/adleatherwood/LeagueOfMonads/badges/master/pipeline.svg)](https://gitlab.com/adleatherwood/LeagueOfMonads/commits/master) | [![coverage report](https://gitlab.com/adleatherwood/LeagueOfMonads/badges/develop/coverage.svg)](https://gitlab.com/adleatherwood/LeagueOfMonads/commits/develop)

### Goal

To provide a collection of monads that work together seemlessly and have a common set of named functions between them.

**NOTE: The library is currently in beta and and exploratory phase.  Not for production use until 1.0.**

### Guidelines
	
* Monads and function should take their queues from other functional languages but try to remain idiomatic to C#.
* Implementations may vary between monads, but should be easy to reason about.
* Monads should implement as many of the common functions as are applicable.
* Monads should support implicit casting when applicable.
* Monads should fully support inheritance when applicable.
* Monads should support IEnumerable< T > when applicable.
* Monads should be serializable.

### Single-Type Monad Functions

| Name            | Sources              | Siganture   |
| ---             | ---                  | ---         |
| Call            | Haskell/Then         | ```Monad<A> . Call<B>(B b) -> B```
| Call            | Haskell/Then         | ```Monad<A> . Call<B>(Task<B> b) -> Task<B>```
| Ignore          | All                  | ```Monad<A> . Ignore() -> void```
| Map             | All                  | ```Monad<A> . Map<B>(Func<A, B> func) -> Monad<B>```
| Map             | All                  | ```Monad<A> . Map<B>(Func<A, Task<B>> func) -> Task<Monad<B>>```
| MapTo           | Haskell/Join,FlatMap | ```Monad<A> . MapTo<B>(Func<A, Monad<B>> func) -> Monad<B>```
| MapTo           | Haskell/Join,FlatMap | ```Monad<A> . MapTo<B>(Func<A, Task<Monad<B>>> func) -> Task<Monad<B>>```
| Tee             | Rop                  | ```Monad<A> . Tee(Action<A> action) -> Monad<A>```
| Tee             | Rop                  | ```Monad<A> . Tee(Func<A, Task> action) -> Task<Monad<A>>```
| ValueOrDefault  | Java/OrElse          | ```Monad<A> . ValueOrDefault(A @default) -> A```
| ValueOrDefault  | Java/OrElse          | ```Monad<A> . ValueOrDefault(Func<A> func) -> A```
| ValueOrDefault  | Java/OrElse          | ```Monad<A> . ValueOrDefault(Func<Task<A>> func) -> Task<A>```
| ValueOrThrow    | Java/OrElseThrow     | ```Monad<A> . ValueOrThrow<E>(string exception) -> A```
| ValueOrThrow    | Java/OrElseThrow     | ```Monad<A> . ValueOrThrow<E>(Func<Exception> f) -> A```

<!-- 
| MapOrCatch      | Rop, C#              | ```Monad<A> . MapOrCatch<B>(Func<A, B> f, Func<A, Exception, Monad<B>> handler) -> Monad<B>``` 
| MapOrThrow      | Rop, C#              | ```Monad<A> . MapOrThrow<B>(Func<A, B> f, Action<A,Exception> handler) -> Monad<B>```) 
| TeeOrCatch      | Rop, C#              | ```Monad<A> . TeeOrCatch(Action<A> f, Action<A, Exception> handler) -> Monadn<A>``` 
| TeeOrThrow      | Rop, C#              | ??? 
-->

<!--
### Multi-Type Monad Functions

| Name            | Sources          | Siganture   |
| ---             | ---              | ---         |
| FirstOrDefault  | New              | ```Monad<A,B> . OtherOrDefault(B @default) -> B```
| FirstOrThrow    | New              | ```Monad<A,B> . OtherOrThrow<E>(string exception) -> B```
| MapAll          | Haskell, Rop     | ```Monad<A,B> . MapAll<C>(Func<A, C> handlerA, Func<B, C> handlerB) -> C```
| MapFirst        | Haskel/Left      | ```Monad<A,B> . MapFirst<C>(Func<A, C> handlerA) -> Option<C>```
| MapSecond       | Haskel/Right     | ```Monad<A,B> . MapSecond<C>(Func<B, C> handlerB) -> Option<C>```
| SecondOrDefault | New              | ```Monad<A,B> . OtherOrDefault(B @default) -> B```
| SecondOrThrow   | New              | ```Monad<A,B> . OtherOrThrow<E>(string exception) -> B```
| TeeFirst        |
| TeeSecond       |

### Functions in Consideration
| Name            | Sources          | Siganture   |
| ---             | ---              | ---         |
| TryMap?         | Rop              | ```Monad<A> . Try<B>(Func<A, B> func) -> Result<B>```
| TryTee?         | Rop, C#          | ???
-->

### Extension-Implemented Type Helpers

| Name            | Sources          | Siganture   |
| ---             | ---              | ---         |
| Enumerate       |                  |

### Currently Implemented Monads

* Identity< T > - This is the equivalent of the Identity type in Haskell.
* Option< T > - This is equivalent to the Option type in F#, or the Maybe type in Haskell
* Either< T, TOther>
* Result< T > 
* LazyTask< T > 

### .Net Types Incorporated via Extension Methods

* Task< T > - Extension Methods
* Lazy< T > - Extension Methods


[Icon Source](http://www.iconarchive.com/show/button-ui-requests-14-icons-by-blackvariant.html)

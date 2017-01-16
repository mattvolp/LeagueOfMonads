# League Of Monads

A gathering place for things that identify as monads but are C# in orientation

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

| Name            | Sources          | Siganture   |
| ---             | ---              | ---         |
| Call            | Haskell/Then     | ```Monad<A> . Call<B>(B b) -> B```
| Ignore          | All              | ```Monad<A> . Ignore() -> void```
| Map             | All              | ```Monad<A> . Map<B>(Func<A, B> func) -> Monad<B>```
| MapOrCatch      | Rop, C#          | ```Monad<A> . MapOrCatch<B>(Func<A, B> f, Func<A, Exception, Monad<B>> handler) -> Monad<B>```
| MapOrThrow      | Rop, C#          | ```Monad<A> . MapOrThrow<B>(Func<A, B> f, Action<A,Exception> handler) -> Monad<B>```
| MapTo           | New              | ```Monad<A> . MapTo<B>(Func<A, B> func) -> B```
| Tee             | Rop              | ```Monad<A> . Tee(Action<A> action) -> Monad<A>```
| TeeOrCatch      | Rop, C#          | ```Monad<A> . TeeOrCatch(Action<A> f, Action<A, Exception> handler) -> Monadn<A>```
| TeeOrThrow      | Rop, C#          | ???
| ValueOrDefault  | Java/OrElse      | ```Monad<A> . ValueOrDefault(A @default) -> A```
| ValueOrThrow    | Java/OrElseThrow | ```Monad<A> . ValueOrThrow<E>(string exception) -> A```

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

### Extension-Implemented Type Helpers

| Name            | Sources          | Siganture   |
| ---             | ---              | ---         |
| Enumerate       |                  |

### Currently Implemented Monads

* Data< T > - This is the equivalent of the Identity type in Haskell.
* Option< T > - This is equivalent to the Option type in F#, or the Maybe type in Haskell
* Either< T, TOther>
* Result< T > 
* LazyTask< T > 

### .Net Types Incorporated via Extension Methods

* Task< T > - Extension Methods
* Lazy< T > - Extension Methods


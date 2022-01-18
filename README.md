# Dotnet Examples

- [C Sharp Language Features](#c-sharp-language-features)
  - [The `init` Accessor](#the-init-accessor)
  - [The `record` Type](#the-record-type)
    - [Records as immutable types](#records-as-immutable-types)
    - [Deciding what type to use](#deciding-what-type-to-use)
  - [Switch Expressions](#switch-expressions)
  - [Pattern Matching](#pattern-matching)
  - [Improved target typing](#improved-target-typing)
    - [Target-typed new expressions](#target-typed-new-expressions)
    - [Target typing with conditional operators](#target-typing-with-conditional-operators)
    - [Covariant returns](#covariant-returns)
- [Feature and Implementation Examples](#feature-and-implementation-examples)
  - [AsyncSocketServerExample](#asyncsocketserverexample)
  - [NamedPipesExample](#namedpipesexample)

## C Sharp Language Features

### The `init` Accessor

Previously, for object initialization to work, the properties must be mutable.

```c#

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string FavoriteColor { get; set; }
}

var person = new Person
{
    FirstName = "Tony",
    LastName = "Stark",
    Address = "10880 Malibu Point",
    City = "Malibu",
    FavoriteColor = "Red"
};
```

To set values in a new Person in an immutable way, you’ll need to call the object’s constructor (in this case, as in most cases, a parameterless constructor) and then perform assignment from the setters.

```c#
public class Person
{
    public Person(string firstName, string lastName, string address, string city, string favoriteColor)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        City = city;
        FavoriteColor = favoriteColor;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public string City { get; }
    public string FavoriteColor { get; }
}
```

With C# 9, we can change this with an init accessor. This means you can only create and set a property when you initialize the object. **Warning**: init-only properties are not mandatory.

```c#
public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string Address { get; init; }
    public string City { get; init; }
    public string FavoriteColor { get; init; }
}

var person = new Person
{
    FirstName = "Tony",
    LastName = "Stark",
    Address = "10880 Malibu Point",
    City = "Malibu",
    FavoriteColor = "Red"
};

```

### The `record` Type

A `struct`, a `class` and a `record` are user data types.

Structures are *value* types. Classes are *reference* types. Records are by default immutable *reference* types.

When you need some sort of hierarchy to describe your data types like inheritance or a struct pointing to another struct or basically things pointing to other things, you need a reference type.

Records solve the problem when you want your type to be a value oriented by default. Records are reference types but with the value oriented semantic.

#### Records as immutable types

What do you get with immutable types? First, you get simplicity. An immutable object only has one state, the state you specified when you created the object. You’ll also see that they are secure and thread-safe with no required synchronization. Because you don’t have threads fighting to change an object, they can be shared freely in your applications.

A record is a construct that allows you to encapsulate property state.
Records allow you to perform value-like behaviours on properties

How is this different than structs? Records are offering the following advantages:

- An easy, simplified construct whose intent is to use as an immutable data structure 
  with easy syntax, like `with` expressions to copy objects
- Robust equality support with `Equals(object)`, `IEquatable<T>`, and `GetHashCode()`
- Constructor/deconstructor support with simplified positional (constructor-based) records

#### Deciding what type to use

Courtesy of [this SO post](https://stackoverflow.com/questions/64816714/when-to-use-record-vs-class-vs-struct)
With that being said, ask yourself these questions...

**Does your data type respect *all* of these rules:**

- It logically represents a single value, similar to primitive types (int, double, etc.).
- It has an instance size under 16 bytes (use `System.Runtime.InteropServices.Marshal.SizeOf(t)` to calculate)
- It is immutable.
- It will not have to be boxed frequently.

If **Yes**, it should be a struct.  If **No** It should be some reference type.

**Does your data type encapsulate some sort of a complex value? Is the value immutable? Do you use it in unidirectional (one way) flow?**

If **Yes**, it should be a record.  If **No** It should be a class.

### Switch Expressions

With switch expressions, we can replace `case` and `:` with `=>` and replace the default statement with a discard `_`. This gives us a much cleaner, expression-like syntax.

Essentially, Switch statements produce go-to like control flow whereas the expressive style forces you to return a value.

```c#
public static string SwitchExpression(string languageInput)
    {
        string languagePhrase = languageInput switch
        {
            "C#" => "C# is fun!",
            "JavaScript" => "JavaScript is mostly fun!",
            _ => throw new Exception("You code in something else I don't recognize."),
        };
        return languagePhrase;
    }
```

### Pattern Matching

Pattern matching allows you to simplify scenarios where you need to cohesively manage data from different sources. An obvious example is when you call an external API where you don’t have any control over the types of data you are getting back.

```c#
        static decimal GetFuelCost(object vehicle) =>
            vehicle switch
            {
                Vehicle s when s.FuelTankSize < 1000 => 10.00m,
                Vehicle s when s.FuelTankSize <= 10000 => 7.00m,
                Animal a => 200.00m,
                _ => throw new ArgumentException("no idea")
            };
```

### Improved target typing

Target typing is what C# uses in expressions for getting a type from it's context. A common example is use of the `var` keyword.

The improved target typing in C# 9 comes in two flavors: new expressions and target-typing `??` and `?:`

#### Target-typed new expressions

```c#
public Person(string firstName, string lastName)
{
        _firstName = firstName;
        _lastName = lastName;
}
///
Person person = new ("Tony", "Stark");
///
var personList = new List<Person>
{
    new ("Tony", "Stark"),
    new ("Howard", "Stark"),
    new ("Clint", "Barton")
};
```

#### Target typing with conditional operators

```c#
// Person is base of Student and Superhero
Student student = new Student ("Dave", "Brock", "Programming");
Superhero hero = new Superhero ("Tony", "Stark", "10000");
Person anotherPerson = student ?? hero;
```

#### Covariant returns

With return type covariance, you can override a base class method (that has a less-specific type) with one that returns a more specific type.

```c#
public virtual Person GetPerson()
{
    // this is the parent (or base) class
    return new Person();
}

public override Student GetPerson()
{
    // derived class
    return new Student();
}
```

---

## Feature and Implementation Examples

### AsyncSocketServerExample

Modern Client/Server example using sockets (via [davidfowl](https://github.com/davidfowl/DotNetCodingPatterns/blob/main/2.md))

### NamedPipesExample

Communicating between processes using Named Pipes (via [ErikEngberg](https://erikengberg.com/named-pipes-in-net-6-with-tray-icon-and-service/))
Includes an interesting place for [desktop icons](https://icon-icons.com/)

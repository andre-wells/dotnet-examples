// What do you get with immutable types? First, you get simplicity. 
// An immutable object only has one state, the state you specified when you created the object. 
// You’ll also see that they are secure and thread-safe with no required synchronization. 
// Because you don’t have threads fighting to change an object, 
// they can be shared freely in your applications.

// A record is a construct that allows you to encapsulate property state.
// Records allow you to perform value-like behaviors on properties

// How is this different than structs? Records are offering the following advantages:

// - An easy, simplified construct whose intent is to use as an immutable data structure 
//   with easy syntax, like `with` expressions to copy objects
// - Robust equality support with Equals(object), IEquatable<T>, and GetHashCode()
// - Constructor/deconstructor support with simplified positional (constructor-based) records

// Deciding when to use Struct, Record or Class:

// Does your data type respect ALL of these rules?
// - It logically represents a single value, similar to primitive types (int, double, etc.).
// - It has an instance size under 16 bytes.
// - It is immutable.
// - It will not have to be boxed frequently.
// If YES then it should be a struct.  If NO then it should be a reference type.

// Does your data type encapsulate some sort of a complex value? 
// Is the value immutable? Do you use it in unidirectional (one way) flow?
// If YES then go with Record. If NO then go with Class.

/// <summary>
/// When you mark a type as record like this, it won’t give you immutability on its own;
/// you’ll need to use init
/// </summary>
public record PersonRecord
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

/// <summary>
/// This will enforce immutability
/// </summary>
public record ImmutablePersonRecord
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;
}

public struct PersonStruct
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public override string ToString() => $"'{FirstName} {LastName}'";
}

/// <summary>
/// To achieve default immutability, you can create objects by using positional arguments (constructor-like syntax). 
/// When you do this, you can declare records with one line
/// </summary>
public record DefaultImmutabilityPositionalArguments(string FirstName, string LastName, int Id);

public record SuperPerson : ImmutablePersonRecord
{
    public int Speed { get; init; }
}

public record Foo(List<string> l);

class RecordsDemo
{
    internal static void CreateAndCopy()
    {
        // Before C# 9, you would represent new state like this
        // This is called "non-desctructive mutation"
        Console.WriteLine();
        Console.WriteLine("Struct Test");
        var st1 = new PersonStruct
        {
            FirstName = "Tony",
            LastName = "Stark"
        };

        var st2 = st1;
        st2.FirstName = "Struct Change";
        Console.WriteLine(st1);
        Console.WriteLine(st2);


        // The same doesn't happen with PersonRecord
        // See how changing rec1 affects rec2. 
        Console.WriteLine();
        Console.WriteLine("Record Test");
        var rec1 = new PersonRecord
        {
            FirstName = "Tony",
            LastName = "Stark"
        };

        var rec2 = rec1;
        rec2.FirstName = "Record Change";
        Console.WriteLine(rec1);
        Console.WriteLine(rec2);

        //With Records, we can make use of `with`.
        Console.WriteLine();
        Console.WriteLine("Immutable Records `with` Test");
        var immutablePerson = new ImmutablePersonRecord
        {
            FirstName = "Tony",
            LastName = "Stark",

        };

        var newImmutablePerson = immutablePerson with { FirstName = "Howard" };
        Console.WriteLine(immutablePerson);
        Console.WriteLine(newImmutablePerson);


        Console.WriteLine();
        Console.WriteLine("Default Immutable Records `with` Test");
        var defaultImmutablePerson = new DefaultImmutabilityPositionalArguments("Tony", "Stark", 1);

        var newDefaultImmutablePerson = defaultImmutablePerson with { FirstName = "Howard", Id = 2 };
        Console.WriteLine(defaultImmutablePerson);
        Console.WriteLine(newDefaultImmutablePerson);

        // A big deal is that records support inheritance where structs do not.
        Console.WriteLine();
        Console.WriteLine("Inheritance with Records");
        var superPerson = new SuperPerson
        {
            FirstName = "Tony",
            LastName = "Stark",
            Speed = 100
        };
        var superPersonCopy = superPerson with { Speed = 50 };
        Console.WriteLine(superPersonCopy);
    }

    internal static void ComparingRecords()
    {
        Console.WriteLine();
        Console.WriteLine("");

        var person = new ImmutablePersonRecord()
        {
            FirstName = "Tony",
            LastName = "Stark"
        };

        var newPerson = person with { FirstName = "Howard" };

        Console.WriteLine($"Object.ReferenceEquals: {Object.ReferenceEquals(person, newPerson)}"); // false
        Console.WriteLine($"Object.Equals: {Object.Equals(person, newPerson)}"); // false

        var anotherPerson = newPerson with { FirstName = "Tony" };
        Console.WriteLine($"Object.Equals {Object.Equals(person, anotherPerson)}"); // true
        Console.WriteLine($"== operator {person == anotherPerson}"); // true

    }

}
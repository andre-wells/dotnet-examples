namespace RecordTypes;

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


/// <summary>
/// When you mark a type as record like this, it won’t give you immutability on its own;
/// you’ll need to use init
/// </summary>
public record PersonRecord
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public override string ToString() => $"'{FirstName} {LastName}'";
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

public record DefaultImmutabilityOneLine(string FirstName, string LastName);

class Demo
{
    internal static void PerformDemo()
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
        var person = new ImmutablePersonRecord
        {
            FirstName = "Tony",
            LastName = "Stark",

        };

        var newPerson = person with { FirstName = "Howard" };
        Console.WriteLine(person);
        Console.WriteLine(newPerson);


        Console.WriteLine();
        Console.WriteLine("Default Immutable Records `with` Test");
        var personDefault = new DefaultImmutabilityOneLine("Tony","Stark");

        var newPersonDefault = personDefault with { FirstName = "Howard" };
        Console.WriteLine(personDefault);
        Console.WriteLine(newPersonDefault);
    }
}
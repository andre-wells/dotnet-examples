class ReadOnlyProperties
{

    public string? FirstName { get; } = null;
    public string LastName { get; } = string.Empty;

    public ReadOnlyProperties(string fname, string lname)
    {
        FirstName = fname;
        LastName = lname;
    }

    static ReadOnlyProperties Create() => new ReadOnlyProperties("a", "b");
}

class InitAccessor
{
    public string FirstName { get; init; } = string.Empty;
    public string LastName { get; init; } = string.Empty;

    static InitAccessor Create() => new InitAccessor
    {
        FirstName = "a",
        LastName = "b"
    };
}
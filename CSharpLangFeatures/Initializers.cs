class ReadOnlyProperties
{

    public string FirstName { get; }
    public string LastName { get; }

    public ReadOnlyProperties(string fname, string lname)
    {
        FirstName = fname;
        LastName = lname;
    }

    static ReadOnlyProperties Create() => new ReadOnlyProperties("a", "b");
}

class InitAccessor
{
    public string FirstName { get; init; } = null;
    public string LastName { get; init; } = null;


}
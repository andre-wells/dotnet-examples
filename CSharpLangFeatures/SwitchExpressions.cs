class SwitchStatementsAndExpressions
{
    /// <summary>
    /// Example of a Switch `statement
    /// </summary>    
    public static string SwitchStatement(string languageInput)
    {
        string languagePhrase;

        switch (languageInput)
        {
            case "C#":
                languagePhrase = "C# is fun!";
                break;
            case "JavaScript":
                languagePhrase = "JavaScript is mostly fun!";
                break;
            default:
                throw new Exception("You code in something else I don't recognize.");
        };
        return languagePhrase;
    }

    /// <summary>
    /// With switch expressions, we can replace `case` and `:` with `=>`
    /// and replace the default statement with _. That “underscore operator” 
    /// is technically called a discard—a temporary, dummy variable that you 
    /// want intentionally unused. 
    /// This gives us a much cleaner, expression-like syntax.
    /// 
    /// Essential, Switch Statements produce goto like control flow
    /// whereas the expressive stile forces you to return a value.
    /// </summary>
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
}
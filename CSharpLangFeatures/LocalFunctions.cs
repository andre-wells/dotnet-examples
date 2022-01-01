
/// <summary>
/// Starting with C# 7.0, C# supports local functions. 
/// Local functions are private methods of a type that are nested in another member. 
/// They can only be called from their containing member.
/// 
/// Watch out for the oddity that (unlike local variables) you can use them 
/// "before you've declared them"; they aren't subject to the same "declaration must appear 
/// nearer the top of the source code than the use"
/// </summary>
class LocalFunctionsDemo
{
    static double GetDistanceBetweenPoints(int x1, int y1, int x2, int y2)
    {
        return Root(Square(x2 - x1) + Square(y2 - y1));

        // In C# 8 and later, a static local function can be used that can't capture local vars or instance state.
        static double Square(int num) => num * 2;

        static double Root(double num) => Math.Sqrt(num);

    }
}
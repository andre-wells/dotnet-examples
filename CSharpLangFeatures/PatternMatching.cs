// Pattern matching works with the is operator and with switch

class Vehicle
{
    public string Name { get; init; } = string.Empty;
    public int FuelTankSize { get; init; }
}

class Animal
{
    public string Name { get; init; } = string.Empty;
    public int Endurance { get; init; }
}

class PatternMatchingDemo
{
    internal static void Run()
    {
        var v = new Vehicle
        {
            Name = "Creta",
            FuelTankSize = 45
        };

        var a = new Animal
        {
            Name = "Battle Cat",
            Endurance = 50
        };

        // Using switch expressions, we can apply a `when` for a case acting on the object.
        // Note how we use Object as an input and do a cast.
        // This came in C# 8
        static decimal GetFuelCostWithPatternMatch(object vehicle) =>
            vehicle switch
            {
                Vehicle s when s.FuelTankSize < 1000 => 10.00m,
                Vehicle s when s.FuelTankSize <= 10000 => 7.00m,
                Animal a => 200.00m,
                _ => throw new ArgumentException("no idea")
            };

        // In C# 9, we can simplify our switch expression using relational patterns.
        // Note we're not assessing the object but switching on the property.
        static decimal GetFuelCostWithRelationalPattern(Vehicle vehicle) => vehicle.FuelTankSize switch
        {
            < 1000 => 10.00m,
            <= 10000 => 7.00m,
            _ => 12.00m
        };
        
        // We can take it forther and make use of logical operators like
        // `and`, `or`, and `not`
        static decimal GetFuelCostWithLogicalPattern(Vehicle vehicle) => vehicle.FuelTankSize switch
        {
            not > 0 => 0.0m,
            1 or 2 => 1.00m,
            < 1000 and < 5000 => 10.00m,
            <= 10000 => 7.00m,            
            _ => 12.00m
        };                

        Console.WriteLine($"GetFuelCostWithPatternMatch (vehicle) {GetFuelCostWithPatternMatch(v)}");
        Console.WriteLine($"GetFuelCostWithPatternMatch (animal) {GetFuelCostWithPatternMatch(a)}");
        Console.WriteLine($"GetFuelCostWithRelationalPattern {GetFuelCostWithRelationalPattern(v)}");
        Console.WriteLine($"GetFuelCostWithLogicalPattern {GetFuelCostWithLogicalPattern(v)}");
    }
}


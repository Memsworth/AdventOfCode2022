namespace AdventOfCode;

public class DayOne
{
    private List<int> Numbers { get; } = new List<int>();
    public void Solve(string FilePath)
    {
        var input = File.ReadAllLines(FilePath);
        var currentTotal = 0;

        foreach (var line in input)
        {
            if (line == String.Empty)
            {
                Numbers.Add(currentTotal);
                currentTotal = 0;
            }
            else
            {
                currentTotal += int.Parse(line);
            }
        }

        Console.WriteLine($"{Numbers.Max()}");
        var sorted = Numbers.OrderByDescending(x => x).Take(3).Sum();
        Console.WriteLine(sorted);
    }
    
}
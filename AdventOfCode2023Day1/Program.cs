using System.Linq;
using System.Text.RegularExpressions;
// See https://aka.ms/new-console-template for more information
var combinedNumbers = new List<int>();
var valueMapping = new Dictionary<string, string>
        {
            { "one", "o1e" },
            { "two", "t2o" },
            { "three", "t3ree" },
            { "four", "f4ur" },
            { "five", "f5ve" },
            { "six", "s6x" },
            { "seven", "s7ven" },
            { "eight", "e8ght" },
            { "nine", "n9ne" },
        };

var filePath = @"AoCDay1Input.txt";
var continueApplication = true;
while (continueApplication)
{
    Console.WriteLine("PART 1 (1), PART 2 (2), or Quit (3)");
    var invalidInput = int.TryParse(Console.ReadLine(), out int input);

    if (!invalidInput)
    {
        Console.WriteLine("Bad Attempt: Invalid character");
    }
    else if (input == 1 || input == 2)
    {
        foreach (var line in File.ReadAllLines(filePath))
        {
            if (input == 1)
                Part1(combinedNumbers, line);
            else
                Part2(combinedNumbers, valueMapping, line);
        }

        var answer = combinedNumbers.Sum();
        Console.WriteLine($"\nThe Answer is: {answer}\n\n");
        combinedNumbers = new List<int>();
    }
    else if (input == 3)
    {
        continueApplication = false;
    }
    else
    {
        Console.WriteLine("Bad Attempt: Number is not recognised input");
    }
}
Console.WriteLine("Exiting Application");
Environment.Exit(0);

#region  PART 1
static void Part1(List<int> combinedNumbers, string line)
{
    var numbers = line.Where(x => int.TryParse(x.ToString(), out _)).ToList();
    char[] numbersArray = { numbers.First(), numbers.Last() };
    string combinedNumberString = new string(numbersArray);
    int.TryParse(combinedNumberString, out int combinedNumber);
    combinedNumbers.Add(combinedNumber);
}
#endregion

#region  PART 2
static void Part2(List<int> combinedNumbers, Dictionary<string, string> valueMapping, string line)
{
    var modifiedLine = line;

    foreach (var mapping in valueMapping)
    {
        var pattern = Regex.Escape(mapping.Key);
        modifiedLine = Regex.Replace(modifiedLine, pattern, mapping.Value);
    }

    var numbers = modifiedLine.Where(x => int.TryParse(x.ToString(), out _)).ToList();
    char[] numbersArray = { numbers.First(), numbers.Last() };
    string combinedNumberString = new string(numbersArray);
    int.TryParse(combinedNumberString, out int combinedNumber);
    combinedNumbers.Add(combinedNumber);
}
#endregion
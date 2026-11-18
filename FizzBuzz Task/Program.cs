
using FizzBuzz_Task;

Console.WriteLine("Please enter your text:");
string input = Console.ReadLine();

FizzBuzzDetector detector = new FizzBuzzDetector();

try
{
    FizzBuzzResult result = detector.getOverlappings(input);

    Console.WriteLine("\nOutput:");
    Console.WriteLine(result.Result);

    Console.WriteLine($"Count: {result.Count}");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Invalid input: {ex.Message}");
}
        
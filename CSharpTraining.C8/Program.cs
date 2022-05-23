using CSharpTraining.C8.Constants;
using CSharpTraining.C8.Models;

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#readonly-members

var point = new Point()
{
    X = 1,
    Y = 2
};

Console.WriteLine(point.ToString());

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#switch-expressions

static string GetRainbowName(Rainbow rainbow) => rainbow switch
{
 
        Rainbow.Blue => "Blue",
        Rainbow.Red => "Red",
        _ => rainbow.ToString()
};

Console.WriteLine(GetRainbowName(Rainbow.Red));

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#property-patterns

static decimal ComputeSalesTax(Address address, decimal salePrice) => address switch
{

    { Name: "First" } => salePrice * 1,
    { State: "Test" } => salePrice * 2,
    { Name: "E", State: "D" } => salePrice * 1,
    _ => salePrice * 0
};

Console.WriteLine(ComputeSalesTax(new Address() { Name = "S"},12));

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#tuple-patterns

static string RockPaperScissors(string first, string second) => (first, second) switch
{
    ("paper","rock") => "Rock is covered by paper. Paper wins.",
    ("rock", "scissors") => "Rock breaks scissors. Rock wins.",
    _ => "Try again please"
};

Console.WriteLine(RockPaperScissors("paper", "rock"));

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#positional-patterns

static Quadrant GetQuadrant(Point point) => point switch
{
    (0, 0) => Quadrant.Origin,
    _ => Quadrant.Unknown
};
Console.WriteLine(GetQuadrant(new Point("Test",0,0)));

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#using-declarations

static string GetFile()
{
    using var file = new StreamReader(@"C:\Eğitim Projeler\csharp-training\test.txt");
    return file.ReadToEnd();
};

Console.WriteLine(GetFile());

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#static-local-functions

static void WriteFile()
{
   Console.WriteLine("Process completed.");
};

WriteFile();


//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#asynchronous-streams
static async IAsyncEnumerable<int> WriteNumberAsyn()
{
    for (int i = 0; i < 5; i++)
    {
        await Task.Delay(1000);
        yield return i;
    }
}

await foreach (var i in WriteNumberAsyn())
{
    Console.WriteLine(i.ToString());
}

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#indices-and-ranges
var words = new string[]
{
                // index from start    index from end
    "The",      // 0                   ^9
    "quick",    // 1                   ^8
    "brown",    // 2                   ^7
    "fox",      // 3                   ^6
    "jumped",   // 4                   ^5
    "over",     // 5                   ^4
    "the",      // 6                   ^3
    "lazy",     // 7                   ^2
    "dog"       // 8                   ^1
};

Console.WriteLine($"The last word is {words[^1]}");
var quickBrownFox = words[1..4]; // quick, brown, fox
var lazyDog = words[^2..^0]; // lazy, dog
var allWords = words[..]; // contains "The" through "dog".
var firstPhrase = words[..4]; // contains "The" through "fox"
var lastPhrase = words[6..]; // contains "the", "lazy" and "dog"

Range phrase = 1..4;
var text = words[phrase];

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#null-coalescing-assignment
List<int>? numbers = null;
int? index = null;

numbers ??= new List<int>();
numbers.Add(index ??= 17);
numbers.Add(index ??= 20);

Console.WriteLine(string.Join(" ", numbers));  // output: 17 17
Console.WriteLine(index);  // output: 17
Console.WriteLine();

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#unmanaged-constructed-types
unsafe static void DisplaySize<T>() where T : unmanaged
{
    Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
}

DisplaySize<Coords<int>>();
DisplaySize<Coords<double>>();

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#stackalloc-in-nested-expressions
static void StackAlloc()
{
    Span<int> numbers = stackalloc[] { 1, 2, 3, 4, 5, 6 };
    var ind = numbers.IndexOfAny(stackalloc[] { 2, 4, 6, 8 });
    Console.WriteLine(ind);  // output: 1
}
StackAlloc();
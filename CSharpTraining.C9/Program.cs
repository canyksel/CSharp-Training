using CSharpTraining.C9.Models;

// https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#record-types

static void GetPerson()
{
    Person person1 = new("Can", "Yüksel");
    Person person2 = new("Can", "Yüksel");
    Console.WriteLine(person1 == person2); // output: True

    Console.WriteLine(person1 == person2); // output: True

    Console.WriteLine(ReferenceEquals(person1, person2)); // output: False


    Person teacher = new Teacher("Can", "Yüksel", 4);
    Person student = new Student("Can", "Yüksel", 4);
    Console.WriteLine(teacher);
    Console.WriteLine(student);
    Console.WriteLine(teacher == student);  // output : False

    Student student2 = new Student("Can", "Yüksel", 4);
    Console.WriteLine(student == student2); // output: True
};
GetPerson();

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#init-only-setters

static void GetWeatherResult()
{
    var now = new WeatherObervation
    {
        RecordedAt = DateTime.Now,
        TemperatureInCelsius = 22,
        PressureInMillibars = 998.0m,
        City = "İstanbul"
    };
    // now.City = "Ankara"; init value olduğundan yeni bir değer set edilemez.(Compiler error)
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.WriteLine(now);
    Console.ForegroundColor = ConsoleColor.White;
};
GetWeatherResult();

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-9#pattern-matching-enhancements
static bool IsLetter(char c) => c is >= 'a' and <= 'z' or >= 'A' and <= 'Z';

Console.WriteLine(IsLetter('8'));
Console.WriteLine(IsLetter('0'));
Console.WriteLine(IsLetter('c'));


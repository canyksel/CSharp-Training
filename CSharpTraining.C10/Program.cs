using CSharpTraining.C10.Models;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#improvements-of-structure-types

var m1 = new Measurement();
Console.WriteLine(m1);  // output: NaN (Undefined)

var m2 = default(Measurement);
Console.WriteLine(m2);  // output: 0 ()

var ms = new Measurement[2];
Console.WriteLine(string.Join(", ", ms));  // output: 0 (), 0 ()

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#extended-property-patterns
static string GetCalendarSeason(DateTime date) => date.Month switch
{
    3 or 4 or 5 => "spring",
    6 or 7 or 8 => "summer",
    9 or 10 or 11 => "autumn",
    12 or 1 or 2 => "winter",
    _ => throw new ArgumentOutOfRangeException(nameof(date), $"Date with unexpected month: {date.Month}."),
};
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 1, 19)));  // output: winter
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 10, 9)));  // output: autumn
Console.WriteLine(GetCalendarSeason(new DateTime(2021, 5, 11)));  // output: spring

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#lambda-expression-improvements
Func<double, double> square = x => x * x;
Console.WriteLine(square(5));

Expression<Func<int, int>> e = x => x * x;
Console.WriteLine(e);

//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#constant-interpolated-strings

const string OldVersion = "9.0";
const string Language = "C#";
const string Platform = ".NET";
const string Version = "10.0";
const string FullProductName = $"{Platform} - Language: {Language} Version: {Version} Old-Version: {OldVersion}";
Console.WriteLine(FullProductName);


//https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-10#callerargumentexpression-attribute-diagnostics


static void Validate(bool condition, [CallerArgumentExpression("condition")] string? message = null)
{
    if (!condition)
    {
        throw new InvalidOperationException($"Argument failed validation: <{message}>");
    }
}

Validate(true,"Error");
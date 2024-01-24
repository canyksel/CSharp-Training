using CsharpTraining.C11.Models;

#region generic-attributes
[Generic<string>()]
static string Method() => default;

[Generic<ValueTuple<int, int>>]
static string Method2() => default;
#endregion

#region numeric-intptr-and-uintptr
int number1 = 12131;
int number2 = Int32.Parse("123");
uint number3 = 2385723852;

long number4 = 721682146124124124;
ulong number6 = 4127498172481241;

IntPtr pointer1 = IntPtr.Parse("1241241");
nint pointer2 = IntPtr.Zero;
#endregion

#region newlines-in-string-interpolations
int safetyScore = 70;
string _ = $"The usage policy for {safetyScore} is {safetyScore switch
{
    > 90 => "Unlimited usage",
    > 80 => "General usage, with daily safety check",
    > 70 => "Issues must be addressed within 1 week",
    > 50 => "Issues must be addressed within 1 day",
    _ => "Issues must be addressed before continued use",
}}";
#endregion

#region list-pattern
int[] numbers = new int[] { 1, 2, 3, 4, 5 };
int[] newNumbers = new int[] { 2, 3, 4, 5 };

if (numbers is [1, 2, 3, 4, 5]) { Console.WriteLine("True"); }
if (numbers is not [1, 2, 3, 4, 5, 6]) { Console.WriteLine("False"); }
if (numbers is [0 or 1, <= 2, >= 3, 4 or >= 4, 5 or <= 5 or 6 or >= 4]) { Console.WriteLine("True"); }

string[] texts = new string[] { "John", "Jack", "Jimmy" };
if (texts is ["John", "Jack", "Jimmy"]) { Console.WriteLine("True"); }
if (texts is not ["John", "Jack"]) { Console.WriteLine("False"); }
#endregion

#region raw-string-literals
string htmlTemplate = """
    <html>
        <div class="body">
            This is a long message.
            It has several lines.
                Some are indented
                        more than others.
            Some should start at the first column.
            Some have "quoted text" in them.
        </div>
    </html>
    """;

string userName = "Can";
double point = 18.18;

var location = $$"""
   Hello {{userName}}, {{point}}
   """;

Console.WriteLine(htmlTemplate);
Console.WriteLine(location);
#endregion


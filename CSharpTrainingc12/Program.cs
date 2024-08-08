using System.Diagnostics.CodeAnalysis;
// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#alias-any-type
#region alias-and-type
using Point3d = (int X, int Y, int Z);

var point = new Point3d(5, 12, 13);
(int x, int y, int z) point2 = new Point3d(6, 8, 10);

#endregion

//https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#collection-expressions
#region collection-expressions
//Before C# 12:
//Create an array:

int[] array = new int[] { 1, 2, 3, 4, 5, 6 };
var array1 = new int[] { 1, 2, 3, 4, 5, 6 };
string[] names = new string[] { "Test", "Test-2", "Test-3" };

//Create a span:
Span<char> span = new char[] { 'a', 'b', 'c', 'd' };

//Create a jagged 2D array:
int[][] matrix = new int[][] { [1, 2, 3], [4, 5, 6] };

// Create a jagged 2D array from variables:
int[] row0 = new int[] { 1, 2, 3 };
int[] row1 = new int[] { 4, 5, 6 };
int[] row2 = new int[] { 7, 8, 6 };
int[][] twoDFromVariables = new int[][] { row0, row1, row2 };

//Dictionary:
Dictionary<string, int> dic = new Dictionary<string, int>();
Dictionary<string, string> dic2 = new();

//With C# 12:
//Create an array:
int[] arrayNewVersion = [1, 3, 4, 5, 6];
//var a = [1,3,4,5, 6]; => //We can't use var anymore. Because we didn't declare type of the array!
string[] namesNewVersion = ["Test", "Test-2", "Test-3"];

//Create a span:
Span<char> spanNewVersion = ['a', 'b', 'c', 'd'];

//Create a jagged 2D array:
int[][] matrixNewVersion = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];

// Create a jagged 2D array from variables:
int[] row0NewVersion = [1, 2, 3];
int[] row1NewVersion = [4, 5, 6];
int[] row2NewVersion = [7, 8, 9];

int[][] twoDFromVariablesNewVersion = [row0, row1, row2];

// Spread element using:
int[] row0Spread = [1, 2, 3];
int[] row1Spread = [4, 5, 6];
int[] row2Spread = [7, 8, 9];
int[] single = [.. row0, .. row1, .. row2]; //We can add all in one array.

foreach (var element in single)
{
    Console.Write($"{element}, ");
}

// output:
// 1, 2, 3, 4, 5, 6, 7, 8, 9,


//Dictionary:
Dictionary<string, int> dicNewVersion = [];
Dictionary<string, string> dic2NewVersion = [];

#endregion

//https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#primary-constructors
#region primary-constructors

//Before C# 12:
/* public class BankAccount
{
    public string AccountID { get; }
    public string Owner { get; }
    public BankAccount(string accountID, string owner)
    {
        AccountID = accountID;
        Owner = owner;
    }
    public override string ToString() => $"Account ID: {AccountID}, Owner: {Owner}";
} */

//With C# 12:
public class BankAccount(string accountID, string owner)
{
    public string AccountID { get; } = accountID;
    public string Owner { get; } = owner;

    public override string ToString() => $"Account ID: {AccountID}, Owner: {Owner}";
}

#endregion

//https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#ref-readonly-parameters
#region ref-readonly-parameters
//Before C# 12:

class RefExample()
{
    public void GetAge(in int age)
    {
        Console.WriteLine($"Age is {age}");
        //age++; => Get an error as: variable 'age' is a readonly variable
    }
}


//With C# 12:
class RefExampleNewVersion()
{
    public void GetAge(ref readonly int age)
    {
        Console.WriteLine($"Age is {age}");
        //age++; => Get an error as: variable 'age' is a readonly variable
    }
}
#endregion

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#default-lambda-parameters
#region default-lambda-parameters
//Before C# 12:

//var lambda = (int age = 30) => $"I am {age} years old."; => We didn't set age without default value.
//lambda();

//After C# 12:

//var lambda = (int age) => $"I am {age} years old."; => We didn't set age without default value.
//lambda(30);
#endregion

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#inline-arrays
#region inline-arrays
/* [InlineArray(10)]
public struct Buffer
{
    private int _element0;
}

var buffer = new Buffer();
for (int i = 0; i < 10; i++)
{
    buffer[i] = i;
}

foreach (var i in buffer)
{
    Console.WriteLine(i);
}

*/
#endregion

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#experimental-attribute
#region experimental-attribute

#pragma warning disable Experimental // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.
//var ex = new ExperimentalAttributeFeature();
#pragma warning restore Experimental // Type is for evaluation purposes only and is subject to change or removal in future updates. Suppress this diagnostic to proceed.

[Experimental("Experimental")]
public class ExperimentalAttributeFeature
{

}
#endregion

// https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-12#interceptors
#region interceptors
//var example = new InterceptableExample();
//example.InterceptableMethod(1); // L1: prints "interceptor 1"
//example.InterceptableMethod(1); // L2: prints "other interceptor 1"
//example.InterceptableMethod(2); // L3: prints "other interceptor 2"
//example.InterceptableMethod(1); // prints "interceptable 1"
public class InterceptableExample
{
    public void InterceptableMethod(int param)
    {
        Console.WriteLine($"interceptable {param}");
    }
}

public static class InterceptorExample
{
    [InterceptsLocation(version: 1, data: "...(refers to the call at L1)")]
    public static void InterceptorMethod(this InterceptableExample example, int param)
    {
        Console.WriteLine($"interceptor {param}");
    }

    [InterceptsLocation(version: 1, data: "...(refers to the call at L2)")]
    [InterceptsLocation(version: 1, data: "...(refers to the call at L3)")]
    public static void OtherInterceptorMethod(this InterceptableExample example, int param)
    {
        Console.WriteLine($"other interceptor {param}");
    }
}

[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
public sealed class InterceptsLocationAttribute(int version, string data) : Attribute
{
}
#endregion
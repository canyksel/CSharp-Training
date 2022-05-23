namespace CSharpTraining.C8.Models
{
    public class Point
    {
        public readonly string Name;
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt(X * X + Y * Y);

        public override string ToString() => $"Name: {Name} ({X}, {Y}) is {Distance} from the origin";
        public Point()
        {
            Name = "Test";
        }

        //https://docs.microsoft.com/en-us/dotnet/csharp/whats-new/csharp-8#positional-patterns
        public Point(string name, double x, double y) => (Name, X, Y) = (name, x, y);
        public void Deconstruct(out double x, out double y) => (x, y) = (X, Y);
    }
}

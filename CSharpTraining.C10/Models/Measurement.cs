namespace CSharpTraining.C10.Models
{
    public readonly struct Measurement
    {
        public double Value { get; init; }
        public string Description { get; init; }

        public Measurement()
        {
            Value = double.NaN;
            Description = "Undefined";
        }

        public Measurement(double value, string description)
        {
            Value = value;
            Description = description;
        }
        public override string ToString() => $"{Value} ({Description})";
    }
}

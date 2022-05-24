namespace CSharpTraining.C9.Models
{
    public struct WeatherObervation
    {
        public DateTime RecordedAt { get; init; }
        public decimal TemperatureInCelsius { get; init; }
        public decimal PressureInMillibars { get; init; }
        public string City { get; init; }

        public override string ToString() => $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: Temp = {TemperatureInCelsius}, with {PressureInMillibars} pressure in {City}";
    }
}

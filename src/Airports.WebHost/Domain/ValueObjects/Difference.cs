using System;

namespace Airports.WebHost.Domain.ValueObjects
{
    public class Difference
    {
        private const int RoundDigits = 2;

        public Location First { get; }

        public Location Second { get; }

        private double? _meters;

        private double? _miles;

        public Difference(Location first, Location second)
        {
            first.ThrowIfNull(nameof(first));
            second.ThrowIfNull(nameof(second));

            First = first;
            Second = second;
        }

        public double Meters => Math.Round(_meters ??= CalculateMeters(), RoundDigits);

        public double Miles => Math.Round(_miles ??= new Miles(Meters).Value, RoundDigits);


        // Was copied from https://stackoverflow.com/a/60809937
        // Original https://stackoverflow.com/a/1502821
        private double CalculateMeters()
        {
            // Earth’s mean radius in meter
            const double earthRadius = 6376500.0;

            const float halfRound = 180.0f;

            var d1 = First.Latitude * (Math.PI / halfRound);
            var num1 = First.Longitude * (Math.PI / halfRound);
            var d2 = Second.Latitude * (Math.PI / halfRound);
            var num2 = Second.Longitude * (Math.PI / halfRound) - num1;

            var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) +
                     Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

            return earthRadius * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
        }
    }
}
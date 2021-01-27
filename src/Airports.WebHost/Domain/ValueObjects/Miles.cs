using System;

namespace Airports.WebHost.Domain.ValueObjects
{
    public class Miles
    {
        private const double Rate = 0.0006213712;

        public Miles(double meters)
        {
            if (meters < 0)
            {
                throw new ArgumentException(message: "Passed argument is negative");
            }

            Value = meters * Rate;
        }

        public double Value { get; }

        public static explicit operator double(Miles instance)
        {
            instance.ThrowIfNull(nameof(instance));
            return instance.Value;
        }
    }
}
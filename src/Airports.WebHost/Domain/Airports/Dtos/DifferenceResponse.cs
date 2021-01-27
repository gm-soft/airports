using Airports.WebHost.Domain.Models;
using Airports.WebHost.Domain.ValueObjects;

namespace Airports.WebHost.Domain.Airports.Dtos
{
    public class DifferenceResponse
    {
        public DifferenceResponse(Airport first, Airport second)
        {
            first.ThrowIfNull(nameof(first));
            second.ThrowIfNull(nameof(second));

            First = first;
            Second = second;
            Difference = new Difference(First.Location, Second.Location);
        }

        public Airport First { get; }

        public Airport Second { get; }

        public Difference Difference { get; }
    }
}
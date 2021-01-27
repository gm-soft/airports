using Airports.WebHost.Domain.ValueObjects;

namespace Airports.WebHost.Domain.Models
{
    public class Airport
    {
        public Airport(string iata, string city, string country, Location location)
        {
            iata.ThrowIfNull(nameof(iata));
            city.ThrowIfNull(nameof(city));
            country.ThrowIfNull(nameof(country));
            location.ThrowIfNull(nameof(location));

            Iata = iata;
            City = city;
            Country = country;
            Location = location;
        }

        public string City { get; protected set; }

        public string Iata { get; protected set; }

        public string Country { get; protected set; }

        public Location Location { get; protected set; }

        public override string ToString()
        {
            return $"{Iata}. Location: {Location.ToString()}";
        }
    }
}
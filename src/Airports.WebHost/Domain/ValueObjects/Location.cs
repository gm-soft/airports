using Newtonsoft.Json;

namespace Airports.WebHost.Domain.ValueObjects
{
    public class Location
    {
        protected Location()
        {
        }

        public Location(double lat, double lon)
        {
            Latitude = lat;
            Longitude = lon;
        }

        [JsonProperty("lat")]
        public double Latitude { get; protected set; }

        [JsonProperty("lon")]
        public double Longitude { get; protected set; }

        public override string ToString()
        {
            return $"Lat: {Latitude}. Lon: {Longitude}";
        }
    }
}
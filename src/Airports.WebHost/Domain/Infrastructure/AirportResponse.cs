using Airports.WebHost.Domain.Models;
using Airports.WebHost.Domain.ValueObjects;
using Newtonsoft.Json;

namespace Airports.WebHost.Domain.Infrastructure
{
    public class AirportResponse
    {
        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("city_iata")]
        public string CityIata { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("country_iata")]
        public string CountryIata { get; set; }

        [JsonProperty("hubs")]
        public int? Hubs { get; set; }

        [JsonProperty("iata")]
        public string Iata { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("timezone_region_name")]
        public string Timezone { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        public Airport Airport()
        {
            return new Airport(Iata, City, Country, Location);
        }
    }
}
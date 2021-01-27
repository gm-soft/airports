using System.ComponentModel.DataAnnotations;

namespace Airports.WebHost.Domain.Airports.Dtos
{
    public class DifferenceBetweenAirportsRequest
    {
        [Required]
        public string First { get; set; }

        [Required]
        public string Second { get; set; }
    }
}
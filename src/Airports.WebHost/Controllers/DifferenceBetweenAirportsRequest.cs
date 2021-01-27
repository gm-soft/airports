using System.ComponentModel.DataAnnotations;

namespace Airports.WebHost.Controllers
{
    public class DifferenceBetweenAirportsRequest
    {
        [Required]
        public string First { get; set; }

        [Required]
        public string Second { get; set; }
    }
}
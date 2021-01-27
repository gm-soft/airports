using System.Threading.Tasks;
using Airports.WebHost.Controllers;
using Airports.WebHost.Domain.Models;
using Airports.WebHost.Domain.ValueObjects;

namespace Airports.WebHost.Domain.Infrastructure
{
    public interface IAirportService
    {
        Task<Airport> ByCodeAsync(string code);

        Task<Difference> DifferenceAsync(DifferenceBetweenAirportsRequest request);
    }
}
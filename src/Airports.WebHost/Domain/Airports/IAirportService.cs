using System.Threading.Tasks;
using Airports.WebHost.Domain.Airports.Dtos;
using Airports.WebHost.Domain.Models;

namespace Airports.WebHost.Domain.Airports
{
    public interface IAirportService
    {
        Task<Airport> ByCodeAsync(string code);

        Task<DifferenceResponse> DifferenceAsync(DifferenceBetweenAirportsRequest request);
    }
}
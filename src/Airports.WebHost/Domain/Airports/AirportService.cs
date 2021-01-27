using System.Threading.Tasks;
using Airports.WebHost.Domain.Airports.Dtos;
using Airports.WebHost.Domain.Infrastructure;
using Airports.WebHost.Domain.Models;

namespace Airports.WebHost.Domain.Airports
{
    public class AirportService : IAirportService
    {
        private readonly IApi _api;

        public AirportService(IApi api)
        {
            _api = api;
        }

        public async Task<Airport> ByCodeAsync(string code)
        {
            code.ThrowIfNull(nameof(code));

            return (await _api.GetAsync<AirportResponse>($"airports/{code.ToUpper()}")).Airport();
        }

        public async Task<DifferenceResponse> DifferenceAsync(DifferenceBetweenAirportsRequest request)
        {
            Airport first = await ByCodeAsync(request.First);
            Airport second = await ByCodeAsync(request.Second);

            return new DifferenceResponse(first, second);
        }
    }
}
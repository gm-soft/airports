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
            var firstCode = request.First.ToUpper();
            var secondCode = request.Second.ToUpper();

            Airport first = await ByCodeAsync(firstCode);

            Airport second = firstCode != secondCode ? await ByCodeAsync(secondCode) : first;

            return new DifferenceResponse(first, second);
        }
    }
}
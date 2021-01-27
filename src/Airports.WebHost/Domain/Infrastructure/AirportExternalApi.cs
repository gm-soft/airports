using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Airports.WebHost.Domain.Exceptions;
using Airports.WebHost.Domain.Models;
using Newtonsoft.Json;

namespace Airports.WebHost.Domain.Infrastructure
{
    public class AirportExternalApi : IAirports
    {
        public const string CTeleport = "cteleport";

        private readonly IHttpClientFactory _clientFactory;

        public AirportExternalApi(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Airport> ByCodeAsync(string code)
        {
            code.ThrowIfNull(nameof(code));

            HttpResponseMessage response = await Client().SendAsync(GetRequest(code.ToUpper()));

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AirportResponse>(responseStream).Airport();
            }

            if (response.StatusCode == HttpStatusCode.BadRequest)
            {
                throw new ResourceNotFoundException($"There is no airport with code {code}");
            }

            throw new InvalidOperationException(
                $"The API response failed. Status: {response.StatusCode}");
        }

        private HttpClient Client()
        {
            return _clientFactory.CreateClient(CTeleport);
        }

        private HttpRequestMessage GetRequest(string code)
        {
            return new HttpRequestMessage(HttpMethod.Get, $"airports/{code}");
        }
    }
}
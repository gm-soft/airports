using System.Threading.Tasks;
using Airports.WebHost.Domain.Models;

namespace Airports.WebHost.Domain.Infrastructure
{
    public interface IAirports
    {
        Task<Airport> ByCodeAsync(string code);
    }
}
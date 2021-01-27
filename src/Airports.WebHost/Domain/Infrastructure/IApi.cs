using System.Threading.Tasks;

namespace Airports.WebHost.Domain.Infrastructure
{
    public interface IApi
    {
        Task<T> GetAsync<T>(string url);
    }
}
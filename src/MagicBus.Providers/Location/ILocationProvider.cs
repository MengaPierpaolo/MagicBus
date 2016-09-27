using System.Threading.Tasks;

namespace MagicBus.Providers.Location
{
    public interface ILocationProvider
    {
        Task<string> GetLastLocation();
    }
}
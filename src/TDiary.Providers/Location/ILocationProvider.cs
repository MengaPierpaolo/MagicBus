using System.Threading.Tasks;

namespace TDiary.Providers.Location
{
    public interface ILocationProvider
    {
        Task<string> GetLastLocation();
    }
}
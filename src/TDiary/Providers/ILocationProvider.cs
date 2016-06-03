using System.Linq;
using TDiary.Model;

namespace TDiary
{
    public interface ILocationProvider
    {
        string GetLastLocation();
    }

}
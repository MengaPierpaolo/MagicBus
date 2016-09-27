using System;
using System.Threading.Tasks;

namespace MagicBus.Providers.LastDate
{
    public interface ILastDateProvider
    {
        Task<DateTime> GetLastDate();
    }
}
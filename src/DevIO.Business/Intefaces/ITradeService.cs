using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ITradeService : IDisposable
    {
        Task Add(Trade trade);
        Task Update(Trade trade);
        Task Remove(Guid id);
    }
}

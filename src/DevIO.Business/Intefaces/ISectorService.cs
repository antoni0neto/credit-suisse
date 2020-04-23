using DevIO.Business.Models;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ISectorService : IDisposable
    {
        Task Add(Sector sector);
        Task Update(Sector sector);
        Task Remove(Guid id);
    }
}

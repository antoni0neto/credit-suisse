using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ITradeRepository : IRepository<Trade>
    {
        Task<List<Trade>> GetAllTradeSectorCategory();
        Task<Trade> GetByIdTradeSectorCategory(Guid id);
        Task<List<Trade>> GetTradesBySector(Guid sectorId);
        Task<List<Trade>> GetTradesByCategory(Guid categoryId);
    }
}

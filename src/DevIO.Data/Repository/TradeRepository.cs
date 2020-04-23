using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class TradeRepository : Repository<Trade>, ITradeRepository
    {
        public TradeRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<List<Trade>> GetAllTradeSectorCategory()
        {
            return await Db.Trades.AsNoTracking()
                .Include(t => t.Sector)
                .Include(t => t.Category)
                .ToListAsync();
        }

        public async Task<Trade> GetByIdTradeSectorCategory(Guid id)
        {
            return await Db.Trades.AsNoTracking()
                .Include(t => t.Sector)
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Trade>> GetTradesBySector(Guid sectorId)
        {
            return await Db.Trades.AsNoTracking()
                .Include(t => t.Sector)
                .Include(t => t.Category)
                .Where(t => t.Sector.Id == sectorId)
                .ToListAsync();
        }

        public async Task<List<Trade>> GetTradesByCategory(Guid categoryId)
        {
            return await Db.Trades.AsNoTracking()
                .Include(t => t.Sector)
                .Include(t => t.Category)
                .Where(t => t.Sector.Id == categoryId)
                .ToListAsync();
        }

        public async Task<Trade> AddTradeWithSector(Trade trade)
        {
            Db.Entry(trade.Sector).State = EntityState.Unchanged;
            Db.Entry(trade.Category).State = EntityState.Unchanged;
            var newTrade = Db.Add(trade);
            Db.SaveChanges();

            return newTrade.Entity;
        }

    }
}
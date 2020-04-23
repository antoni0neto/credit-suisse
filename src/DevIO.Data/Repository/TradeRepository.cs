using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;

namespace DevIO.Data.Repository
{
    public class TradeRepository : Repository<Trade>, ITradeRepository
    {
        public TradeRepository(MyDbContext context) : base(context)
        {
        }

    }
}
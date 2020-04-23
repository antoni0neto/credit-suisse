using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;

namespace DevIO.Data.Repository
{
    public class SectorRepository : Repository<Sector>, ISectorRepository
    {
        public SectorRepository(MyDbContext context) : base(context)
        {
        }

    }
}
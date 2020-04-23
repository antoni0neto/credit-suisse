using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DevIO.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(MyDbContext context) : base(context)
        {
        }

        public async Task<Category> GetCategoryByInitials(string initials)
        {
            return await Db.Categories.AsNoTracking()
                .Include("Sector")
                .FirstOrDefaultAsync(c => c.Initials == initials);
        }
    }
}
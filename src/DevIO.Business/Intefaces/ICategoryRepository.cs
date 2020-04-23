using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetCategoryByInitials(string initials);
    }
}

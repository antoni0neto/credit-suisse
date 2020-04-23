using DevIO.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DevIO.Business.Intefaces
{
    public interface ICategoryService : IDisposable
    {
        Task Add(Category category);
        Task Update(Category category);
        Task Remove(Guid id);
    }
}

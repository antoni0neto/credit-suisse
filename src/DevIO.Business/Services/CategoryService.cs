using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository, 
                                 INotifier notifier) : base(notifier)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task Add(Category category)
        {
            if (!PerformValidation(new CategoryValidation(), category)) return;

            await _categoryRepository.Add(category);
        }

        public async Task Update(Category category)
        {
            if (!PerformValidation(new CategoryValidation(), category)) return;

            await _categoryRepository.Update(category);
        }

        public async Task Remove(Guid id)
        {
            await _categoryRepository.Remove(id);
        }

        public void Dispose()
        {
            _categoryRepository?.Dispose();
        }
    }
}
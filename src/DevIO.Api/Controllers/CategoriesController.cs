using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DevIO.Api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace DevIO.Api.Controllers
{
    [Route("api/categories")]
    public class CategoriesController : MainController
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryRepository categoryRepository, 
                                IMapper mapper, 
                                ICategoryService categoryService,
                                INotifier notificador) : base(notificador)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IEnumerable<CategoryViewModel>> GetAll()
        {
            var mapper = _mapper.Map<IEnumerable<CategoryViewModel>>(await _categoryRepository.GetAll());
            return mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<CategoryViewModel>> GetById(Guid id)
        {
            var category = _mapper.Map<CategoryViewModel>(await _categoryRepository.GetById(id));

            if (category == null) return NotFound();

            return category;
        }

        [HttpPost]
        public async Task<ActionResult<CategoryViewModel>> Add(CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoryService.Add(_mapper.Map<Category>(categoryViewModel));

            return CustomResponse(categoryViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<CategoryViewModel>> Update(Guid id, CategoryViewModel categoryViewModel)
        {
            if (id != categoryViewModel.Id)
            {
                ReportError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(categoryViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _categoryService.Update(_mapper.Map<Category>(categoryViewModel));

            return CustomResponse(categoryViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<CategoryViewModel>> Remove(Guid id)
        {
            var categoryViewModel = await GetById(id);

            if (categoryViewModel == null) return NotFound();

            await _categoryService.Remove(id);

            return CustomResponse(categoryViewModel);
        }
    }
}
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
    [Route("api/sectors")]
    public class SectorsController : MainController
    {
        private readonly ISectorRepository _sectorRepository;
        private readonly ISectorService _sectorService;
        private readonly IMapper _mapper;

        public SectorsController(ISectorRepository sectorRepository, 
                                IMapper mapper, 
                                ISectorService sectorService,
                                INotifier notificador) : base(notificador)
        {
            _sectorRepository = sectorRepository;
            _mapper = mapper;
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<IEnumerable<SectorViewModel>> GetAll()
        {
            var mapper = _mapper.Map<IEnumerable<SectorViewModel>>(await _sectorRepository.GetAll());
            return mapper;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<SectorViewModel>> GetById(Guid id)
        {
            var sector = _mapper.Map<SectorViewModel>(await _sectorRepository.GetById(id));

            if (sector == null) return NotFound();

            return sector;
        }

        [HttpPost]
        public async Task<ActionResult<SectorViewModel>> Add(SectorViewModel sectorViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sectorService.Add(_mapper.Map<Sector>(sectorViewModel));

            return CustomResponse(sectorViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SectorViewModel>> Update(Guid id, SectorViewModel sectorViewModel)
        {
            if (id != sectorViewModel.Id)
            {
                ReportError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(sectorViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sectorService.Update(_mapper.Map<Sector>(sectorViewModel));

            return CustomResponse(sectorViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SectorViewModel>> Remove(Guid id)
        {
            var sectorViewModel = await GetById(id);

            if (sectorViewModel == null) return NotFound();

            await _sectorService.Remove(id);

            return CustomResponse(sectorViewModel);
        }
    }
}
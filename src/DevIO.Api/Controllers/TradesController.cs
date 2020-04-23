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
    [Route("api/trades")]
    public class TradesController : MainController
    {
        private readonly ITradeRepository _tradeRepository;
        private readonly ITradeService _tradeService;
        private readonly IMapper _mapper;

        public TradesController(ITradeRepository tradeRepository, 
                                IMapper mapper, 
                                ITradeService tradeService,
                                INotifier notificador) : base(notificador)
        {
            _tradeRepository = tradeRepository;
            _mapper = mapper;
            _tradeService = tradeService;
        }

        [HttpGet]
        public async Task<IEnumerable<TradeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TradeViewModel>>(await _tradeRepository.GetAllTradeSectorCategory());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<TradeViewModel>> GetById(Guid id)
        {
            var trade = _mapper.Map<TradeViewModel>(await _tradeRepository.GetByIdTradeSectorCategory(id));

            if (trade == null) return NotFound();

            return trade;
        }

        [HttpPost]
        public async Task<ActionResult<TradeViewModel>> Add(TradeViewModel tradeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            //if(tradeViewModel.Value >= 1000000 && tradeViewModel.Sector.Description == "Public")
            //{
            //    tradeViewModel.Category = 
            //}

            await _tradeService.Add(_mapper.Map<Trade>(tradeViewModel));

            return CustomResponse(tradeViewModel);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<TradeViewModel>> Update(Guid id, TradeViewModel tradeViewModel)
        {
            if (id != tradeViewModel.Id)
            {
                ReportError("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(tradeViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _tradeService.Update(_mapper.Map<Trade>(tradeViewModel));

            return CustomResponse(tradeViewModel);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<TradeViewModel>> Remove(Guid id)
        {
            var tradeViewModel = await GetById(id);

            if (tradeViewModel == null) return NotFound();

            await _tradeService.Remove(id);

            return CustomResponse(tradeViewModel);
        }

        [HttpGet("GetByIdTradeSectorCategory/{id}")]
        public async Task<TradeViewModel> GetByIdTradeSectorCategory(Guid id)
        {
            return _mapper.Map<TradeViewModel>(await _tradeRepository.GetByIdTradeSectorCategory(id));
        }

        [HttpGet("GetTradesBySector/{sectorId}")]
        public async Task<TradeViewModel> GetTradesBySector(Guid sectorId)
        {
            return _mapper.Map<TradeViewModel>(await _tradeRepository.GetTradesBySector(sectorId));
        }

        [HttpGet("GetTradesByCategory/{categoryId}")]
        public async Task<TradeViewModel> GetTradesByCategory(Guid categoryId)
        {
            return _mapper.Map<TradeViewModel>(await _tradeRepository.GetTradesByCategory(categoryId));
        }
    }
}
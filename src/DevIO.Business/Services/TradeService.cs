using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class TradeService : BaseService, ITradeService
    {
        private readonly ITradeRepository _tradeRepository;

        public TradeService(ITradeRepository tradeRepository, 
                                 INotifier notifier) : base(notifier)
        {
            _tradeRepository = tradeRepository;
        }

        public async Task Add(Trade trade)
        {
            if (!PerformValidation(new TradeValidation(), trade)) return;

            await _tradeRepository.Add(trade);
        }

        public async Task Update(Trade trade)
        {
            if (!PerformValidation(new TradeValidation(), trade)) return;

            await _tradeRepository.Update(trade);
        }

        public async Task Remove(Guid id)
        {
            await _tradeRepository.Remove(id);
        }

        public void Dispose()
        {
            _tradeRepository?.Dispose();
        }
    }
}
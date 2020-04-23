using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using DevIO.Business.Models.Validations;
using System;
using System.Threading.Tasks;

namespace DevIO.Business.Services
{
    public class SectorService : BaseService, ISectorService
    {
        private readonly ISectorRepository _sectorRepository;

        public SectorService(ISectorRepository sectorRepository, 
                                 INotifier notifier) : base(notifier)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task Add(Sector sector)
        {
            if (!PerformValidation(new SectorValidation(), sector)) return;

            await _sectorRepository.Add(sector);
        }

        public async Task Update(Sector sector)
        {
            if (!PerformValidation(new SectorValidation(), sector)) return;

            await _sectorRepository.Update(sector);
        }

        public async Task Remove(Guid id)
        {
            await _sectorRepository.Remove(id);
        }

        public void Dispose()
        {
            _sectorRepository?.Dispose();
        }
    }
}
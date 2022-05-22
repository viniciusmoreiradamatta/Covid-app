using CovidService.Application.Dtos;
using CovidService.Application.Interfaces;
using CovidService.Domain.Interfaces.Repository;

namespace CovidService.Application.Services
{
    public class CovidAppService : ICovidAppService
    {
        private readonly ICovidRepository _covidRepository;

        public CovidAppService(ICovidRepository covidRepository)
        {
            _covidRepository = covidRepository;
        }

        public async Task<CovidDto> Add(CovidDto item)
        {
            var result = await _covidRepository.Add(item.ToModel());

            await _covidRepository.SaveChanges();

            return result.ToDto();
        }

        public async Task<IEnumerable<CovidDto>> Get()
        {
            var result = await _covidRepository.Get();

            return result.Select(c => c.ToDto());
        }
    }
}

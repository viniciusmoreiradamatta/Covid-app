using CovidService.Application.Dtos;

namespace CovidService.Application.Interfaces
{
    public interface ICovidAppService
    {
        Task<CovidDto> Add(CovidDto item);
        Task<IEnumerable<CovidDto>> Get();

    }
}

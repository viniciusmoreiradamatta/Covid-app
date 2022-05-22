using CovidService.Domain.Interfaces.UnitOfWork;
using CovidService.Domain.Models;

namespace CovidService.Domain.Interfaces.Repository
{
    public interface ICovidRepository: IUnitOfWork
    {
        Task<Covid> Add(Covid item);
        Task<IEnumerable<Covid>> Get();
    }
}
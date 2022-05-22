namespace CovidService.Domain.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}

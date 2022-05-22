using CovidService.Data.Context;
using CovidService.Domain.Interfaces.Repository;
using CovidService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidService.Data.Repository
{
    public class CovidRepository : ICovidRepository
    {
        private readonly CovidContext _context;

        public CovidRepository(CovidContext context)
        {
            _context = context;
        }

        public async Task<Covid> Add(Covid item)
        {
            var covidItem = await _context.Covid.AddAsync(item);

            return covidItem.Entity;
        }

        public async Task<IEnumerable<Covid>> Get() => await
            _context.Covid.AsNoTrackingWithIdentityResolution().ToListAsync();

        public async Task SaveChanges() => await _context.SaveChangesAsync();
    }
}

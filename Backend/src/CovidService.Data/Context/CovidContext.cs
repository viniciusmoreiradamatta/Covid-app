using CovidService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CovidService.Data.Context
{
    public class CovidContext : DbContext
    {
        public CovidContext(DbContextOptions op) : base(op)
        {
            Database.EnsureCreated();
        }

        public DbSet<Covid> Covid { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}

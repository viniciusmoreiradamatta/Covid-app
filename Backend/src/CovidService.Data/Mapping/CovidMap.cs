using CovidService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CovidService.Data.Mapping
{
    public class CovidMap : IEntityTypeConfiguration<Covid>
    {
        public void Configure(EntityTypeBuilder<Covid> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(c => c.Country).HasMaxLength(100).IsRequired();
            builder.Ignore(c=> c.Valid);
            builder.Ignore(c=> c.ValidationResult);
        }
    }
}

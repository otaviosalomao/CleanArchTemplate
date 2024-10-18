using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Configuration
{
    public class SampleEntityConfiguration
    {
        public void Configure(EntityTypeBuilder<SampleEntity> builder)
        {
            builder.HasKey(u => new { u.Id });
            builder.Property(f => f.Id).ValueGeneratedOnAdd();
        }
    }
}

using Lista69B.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.DB.Config
{
    public class ConfigWatchListSweep : IEntityTypeConfiguration<WatchListSweep>
    {
        public void Configure(EntityTypeBuilder<WatchListSweep> builder)
        {
            builder.ToTable("WathcListSweep");
            builder.HasKey(x => x.Id).HasName("WathcListSweepId");
            builder.HasMany(x => x.Founds).WithOne(x => x.WatchListSweep).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.WatchListSweepId);
        }
    }
}

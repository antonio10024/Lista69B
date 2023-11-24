using Lista69B.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista69B.Infrastructure.DB.Config
{
    public class ConfigFoundWatchList : IEntityTypeConfiguration<FoundWatchList>
    {
        public void Configure(EntityTypeBuilder<FoundWatchList> builder)
        {
            builder.ToTable("WathcListSweepDetail");
            builder.HasKey(x => x.Id).HasName("WathcListSweepDetailId");
            builder.HasOne(x => x.WatchListSweep).WithMany(x => x.Founds).HasPrincipalKey(x => x.Id).HasForeignKey(x => x.WatchListSweepId);
        }
    }
}

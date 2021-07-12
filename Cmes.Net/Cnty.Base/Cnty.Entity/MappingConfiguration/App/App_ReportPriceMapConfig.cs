using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class App_ReportPriceMapConfig : EntityMappingConfiguration<App_ReportPrice>
    {
        public override void Map(EntityTypeBuilder<App_ReportPrice>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


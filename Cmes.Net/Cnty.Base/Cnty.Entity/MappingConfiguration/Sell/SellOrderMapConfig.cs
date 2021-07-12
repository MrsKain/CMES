using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class SellOrderMapConfig : EntityMappingConfiguration<SellOrder>
    {
        public override void Map(EntityTypeBuilder<SellOrder>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


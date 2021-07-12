using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class vProvinceCityMapConfig : EntityMappingConfiguration<vProvinceCity>
    {
        public override void Map(EntityTypeBuilder<vProvinceCity>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


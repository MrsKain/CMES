using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class Scada_Data_DemoMapConfig : EntityMappingConfiguration<Scada_Data_Demo>
    {
        public override void Map(EntityTypeBuilder<Scada_Data_Demo>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


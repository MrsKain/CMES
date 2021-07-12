using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class Rgm_In_DataMapConfig : EntityMappingConfiguration<Rgm_In_Data>
    {
        public override void Map(EntityTypeBuilder<Rgm_In_Data>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


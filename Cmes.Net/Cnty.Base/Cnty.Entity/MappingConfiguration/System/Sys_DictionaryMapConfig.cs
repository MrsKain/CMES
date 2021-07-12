using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class Sys_DictionaryMapConfig : EntityMappingConfiguration<Sys_Dictionary>
    {
        public override void Map(EntityTypeBuilder<Sys_Dictionary>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class App_TransactionMapConfig : EntityMappingConfiguration<App_Transaction>
    {
        public override void Map(EntityTypeBuilder<App_Transaction>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


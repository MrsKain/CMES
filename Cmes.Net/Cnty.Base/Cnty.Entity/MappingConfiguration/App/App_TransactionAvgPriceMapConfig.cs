using Cnty.Entity.MappingConfiguration;
using Cnty.Entity.DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cnty.Entity.MappingConfiguration
{
    public class App_TransactionAvgPriceMapConfig : EntityMappingConfiguration<App_TransactionAvgPrice>
    {
        public override void Map(EntityTypeBuilder<App_TransactionAvgPrice>
        builderTable)
        {
          //b.Property(x => x.StorageName).HasMaxLength(45);
        }
     }
}


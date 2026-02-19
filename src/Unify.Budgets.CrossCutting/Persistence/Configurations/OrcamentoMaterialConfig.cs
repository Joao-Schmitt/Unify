using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.CrossCutting.Persistence.Configurations
{
    public class OrcamentoMaterialConfig : EntityTypeConfiguration<OrcamentoMaterial>
    {
        public OrcamentoMaterialConfig()
        {
            ToTable("OrcamentoMateriais");

            HasKey(x => x.Id);

            Property<long>(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        }
    }

}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unify.Budgets.Domain.Entities;

namespace Unify.Budgets.CrossCutting.Persistence.Configurations
{
    public class ServicoConfig : EntityTypeConfiguration<Servico>
    {
        public ServicoConfig()
        {
            ToTable("Servicos");

            HasKey(x => x.Id);

            Property<long>(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(120).IsRequired();
            Property(x => x.PrecoBase).IsRequired();
        }
    }
}

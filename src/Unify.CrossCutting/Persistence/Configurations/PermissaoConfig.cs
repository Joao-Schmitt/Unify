using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unify.Domain.Entities;

namespace Unify.CrossCutting.Persistence.Configurations
{
    public class PermissaoConfig : EntityTypeConfiguration<Permissoes>
    {
        public PermissaoConfig()
        {
            ToTable("Permissoes");

            HasKey(x => x.Id);

            Property<long>(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Codigo).HasMaxLength(80).IsRequired();
            Property(x => x.Descricao).HasMaxLength(120);

            HasIndex(x => x.Codigo).IsUnique();
        }
    }

}

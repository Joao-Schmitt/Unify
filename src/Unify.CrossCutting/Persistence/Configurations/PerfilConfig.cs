using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Unify.Domain.Entities;

namespace Unify.CrossCutting.Persistence.Configurations
{
    public class PerfilConfig : EntityTypeConfiguration<Perfil>
    {
        public PerfilConfig()
        {
            ToTable("Perfis");

            HasKey(x => x.Id);

            Property<long>(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(50).IsRequired();
        }

    }
}

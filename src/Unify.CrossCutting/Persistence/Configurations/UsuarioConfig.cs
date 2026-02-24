using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unify.Domain.Entities;

namespace Unify.CrossCutting.Persistence.Configurations
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            ToTable("Usuarios");

            HasKey(x => x.Id);

            Property<long>(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(120).IsRequired();
            Property(x => x.Email).HasMaxLength(120).IsRequired();

            Property<long>(x => x.PerfilId); // FK BIGINT

            HasRequired(x => x.Perfil)
                .WithMany()
                .HasForeignKey(x => x.PerfilId);
        }
    }

}

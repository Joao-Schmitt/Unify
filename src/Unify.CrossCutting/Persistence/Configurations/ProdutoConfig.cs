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
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            ToTable("Produtos");

            HasKey(x => x.Id);

            Property<long>(x => x.Id)
                .HasColumnName("Id")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(x => x.Nome).HasMaxLength(120).IsRequired();
            Property(x => x.Unidade).HasMaxLength(3);
            Property(x => x.PrecoUnidade);
            Property(x => x.Ativo);
        }
    }

}

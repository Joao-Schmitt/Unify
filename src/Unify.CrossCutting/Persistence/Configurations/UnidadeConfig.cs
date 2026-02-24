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
    public class UnidadeConfig : EntityTypeConfiguration<Unidade>
    {
        public UnidadeConfig()
        {
            ToTable("Unidades");
            HasKey(x => x.Id);
        }
    }

}

using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.EntityConfig
{
    public class PessoaConfig : EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.DataCadastro)
                .IsRequired();

            HasRequired(x => x.PessoaFisica)
                .WithRequiredPrincipal(x => x.Pessoa)
                .WillCascadeOnDelete(true);
            //HasOptional(x => x.PessoaFisica)
            //    .WithRequired(x => x.Pessoa);
        }
    }
}
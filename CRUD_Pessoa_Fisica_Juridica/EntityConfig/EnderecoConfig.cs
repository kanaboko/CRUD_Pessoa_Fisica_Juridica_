using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.EntityConfig
{
    public class EnderecoConfig: EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);
            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(200);
            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10);
            Property(e => e.Cidade)
                .HasMaxLength(50);
            

        }
    }
}
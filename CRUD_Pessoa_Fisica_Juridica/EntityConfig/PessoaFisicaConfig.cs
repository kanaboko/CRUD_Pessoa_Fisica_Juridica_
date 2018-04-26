using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.EntityConfig
{
    public class PessoaFisicaConfig: EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfig()
        {
            HasKey(pf => pf.Id);
            Property(pf => pf.Nome)
                .IsRequired()
                .HasMaxLength(150);
            Property(pf => pf.Rg)
                .IsRequired()
                .HasMaxLength(9);
            Property(pf => pf.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            //HasRequired(pf => pf.Pessoa)
            //    .WithRequiredPrincipal(pf => pf.PessoaFisica);
            
            HasMany(e => e.Enderecos)
                .WithMany()
                .Map(me =>
                {                   
                    me.MapLeftKey("PessoaFisicaId");
                    me.MapRightKey("EnderecoId");
                    me.ToTable("PessoaFisicaEndereco");
                });

            ToTable("Pessoas_Fisicas");
                
           
        }
    }
}
using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.EntityConfig
{
    public class PessoaJuridicaConfig: EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfig()
        {
            HasKey(pj => pj.Id);
            Property(pj => pj.Cnpj)
                .IsRequired()
                .HasMaxLength(14)
                .IsFixedLength();
            Property(pj => pj.RazaoSocial)
                .IsRequired()
                .HasMaxLength(150);
            HasRequired(pj => pj.Pessoa)
                .WithMany(pj => pj.PessoaJuridica)
                .HasForeignKey(pj => pj.PessoaId);
            
            HasMany(pj => pj.Enderecos)
                .WithMany()                
                .Map(e =>
                {
                    e.MapLeftKey("PessoaJuridicaId");
                    e.MapRightKey("EnderecoId");
                    e.ToTable("PessoaJuridicaEnderecos");
                    
                });

            ToTable("Pessoas_Juridicas");

        }
    }
}
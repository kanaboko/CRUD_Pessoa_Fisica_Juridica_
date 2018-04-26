using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.Models
{
    public class Pessoa
    {
        public Pessoa()
        {
            Id = Guid.NewGuid();
            PessoaJuridica = new List<PessoaJuridica>();
            
        }

        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public TipoPessoa TipoPessoa { get; set; }

        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual ICollection<PessoaJuridica> PessoaJuridica { get; set; }

        public void AdicionarPessoaJuridica(PessoaJuridica pj)
        {
            PessoaJuridica.Add(pj);
        }


    }

    public enum TipoPessoa
    {
        PessoaFisica,
        PessoaJuridica
    };
}
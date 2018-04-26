using System;
using System.Collections.Generic;

namespace CRUD_Pessoa_Fisica_Juridica.Models
{
    public class PessoaJuridica
    {
        public PessoaJuridica()
        {
            Id = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }

        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public Guid PessoaId { get; set; }
        public virtual Pessoa Pessoa { get; set; }
        public ICollection<Endereco> Enderecos { get; set; }

        public void AdicionarEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }
    }
}
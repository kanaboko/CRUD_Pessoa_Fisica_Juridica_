using System;
using System.Collections.Generic;

namespace CRUD_Pessoa_Fisica_Juridica.Models
{
    public class PessoaFisica
    {
        public PessoaFisica()
        {
            Id = Guid.NewGuid();
            Enderecos = new List<Endereco>();
        }
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Rg { get; set; }
        public string Cpf { get; set; }
        

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Endereco> Enderecos { get; set; }

        public void AdicionarEndereco(Endereco endereco)
        {
            Enderecos.Add(endereco);
        }
    }
}
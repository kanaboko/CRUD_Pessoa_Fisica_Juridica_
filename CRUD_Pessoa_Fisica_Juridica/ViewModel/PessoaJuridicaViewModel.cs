using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Pessoa_Fisica_Juridica.ViewModel
{
    public class PessoaJuridicaViewModel
    {
        public PessoaJuridicaViewModel()
        {
            Id = Guid.NewGuid();
            Enderecos = new List<EnderecoViewModel>();
        }
        [Key]
        public Guid Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public Guid PessoaId { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }
    }
}
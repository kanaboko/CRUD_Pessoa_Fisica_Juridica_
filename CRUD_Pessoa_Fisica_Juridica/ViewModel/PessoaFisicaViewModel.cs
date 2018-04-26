using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.ViewModel
{
    public class PessoaFisicaViewModel
    {
        public PessoaFisicaViewModel()
        {
            Id = Guid.NewGuid();
            Enderecos = new List<EnderecoViewModel>();
        }
        
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(150, ErrorMessage ="Foi ultrapassado o limite de 150 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(10, ErrorMessage = "Foi ultrapassado o limite de 10 caracteres")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Preencha o campo CPF")]
        [MaxLength(11, ErrorMessage = "Foi ultrapassado o limite de 11 caracteres")]
        public string Cpf { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
        public virtual ICollection<EnderecoViewModel> Enderecos { get; set; }
    }
}
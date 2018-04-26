using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Pessoa_Fisica_Juridica.ViewModel
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Id = Guid.NewGuid();

            PessoaJuridica = new List<PessoaJuridicaViewModel>();
        }
        [Key]
        public Guid Id { get; set; }
        [Display(Name = "Data de cadastro")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato invalido")]
        public DateTime DataCadastro { get; set; }           
        public ListaTipoPessoa TipoPessoa { get; set; }

        public virtual PessoaFisicaViewModel PessoaFisica { get; set; }
        public virtual ICollection<PessoaJuridicaViewModel> PessoaJuridica { get; set; }

        
    }
    public enum ListaTipoPessoa
    {
        [Display(Name = "Pessoa Fisica")]
        PessoaFisica,
        [Display(Name = "pessoa juridica")]
        PessoaJuridica
    }

}
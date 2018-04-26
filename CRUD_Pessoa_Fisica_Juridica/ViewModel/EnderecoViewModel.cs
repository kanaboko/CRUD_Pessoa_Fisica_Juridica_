using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Pessoa_Fisica_Juridica.ViewModel
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(200, ErrorMessage = "Foi ultrapassado o limite de 200 caracteres")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Preencha o campo Numero")]
        [MaxLength(10, ErrorMessage = "Foi ultrapassado o limite de 10 caracteres")]
        public string Numero { get; set; }
        public string Cidade { get; set; }
    }
}
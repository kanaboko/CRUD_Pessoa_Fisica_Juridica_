using System;

namespace CRUD_Pessoa_Fisica_Juridica.Models
{
    public class Endereco
    {
        public Endereco()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }

    }
}
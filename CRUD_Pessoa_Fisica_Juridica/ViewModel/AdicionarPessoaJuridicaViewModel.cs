using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.ViewModel
{
    public class AdicionarPessoaJuridicaViewModel
    {
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }
        public EnderecoViewModel Endereco { get; set; }
    }
}
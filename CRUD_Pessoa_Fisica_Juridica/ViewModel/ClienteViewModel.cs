using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.ViewModel
{
    public class ClienteViewModel
    {
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }
        public EnderecoViewModel EnderecoJuridico { get; set; }
        public PessoaFisicaViewModel PessoaFisica { get; set; }
        public EnderecoViewModel EnderecoFisico { get; set; }
        public PessoaViewModel Pessoa { get; set; }
    }
}
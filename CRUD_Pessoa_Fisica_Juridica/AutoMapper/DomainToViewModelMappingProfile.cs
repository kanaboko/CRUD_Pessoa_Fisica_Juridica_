using AutoMapper;
using CRUD_Pessoa_Fisica_Juridica.Models;
using CRUD_Pessoa_Fisica_Juridica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();           
            CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            //CreateMap<Pessoa, PessoaFisicaEnderecoViewModel>()
            //    .ForMember(dest => dest.Pessoa.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Pessoa.DataCadastro, opt => opt.MapFrom(src => src.DataCadastro))
            //    .ForMember(dest => dest.PessoaFisica, opt => opt.MapFrom(src => src.PessoaFisica))
            //    .ForMember(dest => dest.PessoaFisica.Id, opt => opt.MapFrom(src => src.PessoaFisica.Id))
            //    .ForMember(dest => dest.PessoaFisica.Cpf, opt => opt.MapFrom(src => src.PessoaFisica.Cpf))
            //    .ForMember(dest => dest.PessoaFisica.Nome, opt => opt.MapFrom(src => src.PessoaFisica.Nome))
            //    .ForMember(dest => dest.PessoaFisica.Rg, opt => opt.MapFrom(src => src.PessoaFisica.Rg))
            //    .ForMember(dest => dest.EnderecoFisico, opt => opt.MapFrom(src => src.PessoaFisica.Enderecos))                
            //    .ForMember(dest => dest.PessoaJuridica, opt => opt.MapFrom(src => src.PessoaJuridica))
            //    .ForMember(dest => dest.PessoaJuridica.Cnpj, opt => opt.MapFrom(src => src.PessoaJuridica))
            //    .ForMember(dest => dest.PessoaFisica, opt => opt.MapFrom(src => src.PessoaFisica))
            //    .ForMember(dest => dest.Pessoa, opt => opt.MapFrom(src => src));
        }
    }
}
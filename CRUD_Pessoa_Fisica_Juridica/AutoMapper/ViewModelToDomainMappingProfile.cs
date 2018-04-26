using AutoMapper;
using CRUD_Pessoa_Fisica_Juridica.Models;
using CRUD_Pessoa_Fisica_Juridica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<PessoaFisicaViewModel, PessoaFisica>();
            CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            CreateMap<EnderecoViewModel, Endereco>();
            //CreateMap<PessoaFisicaEnderecoViewModel, Pessoa>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Pessoa.Id))
            //    .ForMember(dest => dest.DataCadastro, opt => opt.MapFrom(src => src.Pessoa.DataCadastro))
            //    .ForMember(dest => dest.PessoaFisica, opt => opt.MapFrom(src => src.PessoaFisica))
            //    .ForMember(dest => dest.PessoaFisica.Id, opt => opt.MapFrom(src => src.PessoaFisica.Id))
            //    .ForMember(dest => dest.PessoaFisica.Cpf, opt => opt.MapFrom(src => src.PessoaFisica.Cpf))
            //    .ForMember(dest => dest.PessoaFisica.Enderecos, opt => opt.MapFrom(src => src.PessoaFisica.Enderecos))
            //    .ForMember(dest => dest.PessoaFisica.Nome, opt => opt.MapFrom(src => src.PessoaFisica.Nome))
            //    .ForMember(dest => dest.PessoaFisica.Pessoa, opt => opt.MapFrom(src => src.PessoaFisica.Pessoa))
            //    .ForMember(dest => dest.PessoaFisica.Rg, opt => opt.MapFrom(src => src.PessoaFisica.Rg))                
            //    .ForMember(dest => dest.PessoaFisica.Enderecos, opt => opt.MapFrom(src => src.PessoaFisica.Enderecos))
            //    .ForMember(dest => dest, opt => opt.MapFrom(src => src));
        }
    }
}
using AutoMapper;
using CRUD_Pessoa_Fisica_Juridica.Models;
using CRUD_Pessoa_Fisica_Juridica.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.Service
{
    public class Service_CRUD
    {
        private readonly Repository.Repository<Pessoa> repository;
        private readonly Repository.Repository<Endereco> repositoryEndereco;
        private readonly Repository.Repository<PessoaFisica> repositoryFisica;
        private readonly Repository.Repository<PessoaJuridica> repositoryJuridica;
        private readonly Repository.Repositorypessoa repositoryPessoa;

        public Service_CRUD()
        {
            repository = new Repository.Repository<Pessoa>();
            repositoryEndereco = new Repository.Repository<Endereco>();
            repositoryFisica = new Repository.Repository<PessoaFisica>();
            repositoryJuridica = new Repository.Repository<PessoaJuridica>();
            repositoryPessoa = new Repository.Repositorypessoa();
        }

        //Setor de leitura utilizando Dapper
        #region Leitura

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PessoaViewModel>>(repositoryPessoa.ObterTodos());
        }    

        public EnderecoViewModel ObterEnderecoPorId(Guid id)
        {
            return Mapper.Map<EnderecoViewModel>(repositoryPessoa.ObterPorIdEndereco(id));
        }

        public PessoaViewModel ObterPorIdPessoa(Guid id)
        {
            return Mapper.Map<PessoaViewModel>(repositoryPessoa.ObterPorIdPessoa(id));
        }

        public PessoaFisicaViewModel ObterEnderecoPorPessoaFisica(Guid id)
        {
            return Mapper.Map<PessoaFisicaViewModel>(repositoryPessoa.ObterEnderecoPorPessoaFisica(id));
        }

        public PessoaJuridicaViewModel ObterEnderecoPorPessoaJuridica(Guid id)
        {
            return Mapper.Map<PessoaJuridicaViewModel>(repositoryPessoa.ObterEnderecoPorPessoaJuridica(id));
        }

        public PessoaViewModel ObterPorIdPessoaFisica(Guid id)
        {
            return Mapper.Map<PessoaViewModel>(repositoryPessoa.ObterPorIdPessoaFisica(id));
        }

        public PessoaJuridicaViewModel ObterPorIdPessoaJuridica(Guid id)
        {
            return Mapper.Map<PessoaJuridicaViewModel>(repositoryPessoa.ObterPorIdPessoaJuridica(id));
        }

        #endregion Leitura

        //Setor de Gravação utilizando o ORM EntityFramework

        #region Gravacao

        public void Adicionar(ClienteViewModel obj)
        {
            var pessoa = Mapper.Map<Pessoa>(obj.Pessoa);
            var pessoaFisica = Mapper.Map<PessoaFisica>(obj.PessoaFisica);
            var pessoaJuridica = Mapper.Map<PessoaJuridica>(obj.PessoaJuridica);
            var enderecoFisico = Mapper.Map<Endereco>(obj.EnderecoFisico);
            var enderecoJuridico = Mapper.Map<Endereco>(obj.EnderecoJuridico);

            pessoa.PessoaFisica = pessoaFisica;
            pessoaFisica.AdicionarEndereco(enderecoFisico);
            pessoaJuridica.AdicionarEndereco(enderecoJuridico);
            pessoa.AdicionarPessoaJuridica(pessoaJuridica);
           
            repository.Adicionar(pessoa);

        }

        public void AdicionarEndereco(EnderecoViewModel endereco, Guid pessoaId, string tipo)
        {
            if(endereco != null && tipo == "enderecoJuridico")
            {
                var pessoa = repositoryJuridica.ObterPorId(pessoaId);
                pessoa.AdicionarEndereco(Mapper.Map<Endereco>(endereco));
                repositoryJuridica.Atualizar(pessoa);
            } else if (endereco != null && tipo == "enderecoFisico")
            {
                var pessoa = repositoryFisica.ObterPorId(pessoaId);
                pessoa.AdicionarEndereco(Mapper.Map<Endereco>(endereco));
                repositoryFisica.Atualizar(pessoa);
            }
        }

        public void AdicionarPessoaJuridica(AdicionarPessoaJuridicaViewModel pessoaJuridica)
        {
            var pessoa = Mapper.Map<PessoaJuridica>(pessoaJuridica.PessoaJuridica);            
            pessoa.AdicionarEndereco(Mapper.Map<Endereco>(pessoaJuridica.Endereco));
            repositoryJuridica.Adicionar(pessoa);
        }       

        public PessoaViewModel AtualizarPessoa(PessoaViewModel obj)
        {
            var pessoa = Mapper.Map<Pessoa>(obj);            
            repository.Atualizar(pessoa);
            return obj;
        }

        public PessoaFisicaViewModel AtualizarPessoaFisica(PessoaFisicaViewModel obj)
        {
            var pessoaFisica = Mapper.Map<PessoaFisica>(obj);
            repositoryFisica.Atualizar(pessoaFisica);

            return obj;
        }

        public PessoaJuridicaViewModel AtualizarPessoaJuridica(PessoaJuridicaViewModel obj)
        {            
            var pessoaJuridica = Mapper.Map<PessoaJuridica>(obj);
            repositoryJuridica.Atualizar(pessoaJuridica);

            return obj;
        }

        public EnderecoViewModel AtualizarEndereco(EnderecoViewModel obj)
        {
            var endereco = Mapper.Map<Endereco>(obj);
            repositoryEndereco.Atualizar(endereco);

            return obj;
        }

        #endregion Gravacao

        // Setor de Remocao

        public void Remover(Guid id)
        {
            repository.Remover(id);
        }

        public void RemoverEndereco(Guid id)
        {
            repositoryEndereco.Remover(id);
        }

        public void RemoverPessoaJuridica(Guid id)
        {
            repositoryJuridica.Remover(id);
        }


    }
}
using CRUD_Pessoa_Fisica_Juridica.Context;
using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.Repository
{
    public class Repositorypessoa: Repository<Pessoa>
    {
        protected CRUD_Context context;
        protected DbSet<Pessoa> dbSet;
        protected System.Data.Common.DbConnection cn;
        public Repositorypessoa()
        {
            context = new CRUD_Context();
            dbSet = context.Set<Pessoa>();
            cn = context.Database.Connection;
        }       
        
        public IEnumerable<Pessoa> ObterTodos()
        {
            var pessoa = new List<Pessoa>();
            var sql = @"SELECT * FROM dbo.Pessoa p
LEFT JOIN dbo.Pessoas_Fisicas f ON f.Id = p.Id
LEFT JOIN dbo.Pessoas_Juridicas j ON j.PessoaId = p.Id";
            cn.Query<Pessoa, PessoaFisica, PessoaJuridica, Pessoa>(sql, (p, f, j) =>
            {
                if(p != null && !pessoa.Exists(src => src.Id == p.Id))
                {
                    pessoa.Add(p);
                }
                if (pessoa.Count() > 0)
                {
                    for (int i = 0; i < pessoa.Count(); i++)
                    {
                        if(f!=null && pessoa[i].Id == f.Id)
                        {
                            pessoa[i].PessoaFisica = f;
                        }
                        if(j!=null && pessoa[i].Id == j.PessoaId)
                        {
                            pessoa[i].AdicionarPessoaJuridica(j);
                        }
                    }
                }
                return pessoa.FirstOrDefault();
            });

            return pessoa;

        }
        public Pessoa ObterPorIdPessoa(Guid id)
        {
            var pessoaListTest = new List<Pessoa>();
            var pessoaList = new List<Pessoa>();
            var pessoaJuridicaList = new List<PessoaJuridica>();
            var enderecoList = new List<Endereco>();
            var sql = @"SELECT * FROM dbo.Pessoa p
            INNER JOIN dbo.Pessoas_Fisicas f ON p.Id = f.Id
            LEFT JOIN dbo.PessoaFisicaEndereco x ON f.Id = x.PessoaFisicaId
            LEFT JOIN dbo.Endereco r ON x.EnderecoId = r.Id
            WHERE p.Id = @sid; SELECT * FROM dbo.Pessoa p            
            INNER JOIN dbo.Pessoas_Juridicas j ON p.Id = j.PessoaId
            LEFT JOIN dbo.PessoaJuridicaEnderecos y ON y.PessoaJuridicaId = j.Id
            LEFT JOIN dbo.Endereco e ON y.EnderecoId = e.Id
            WHERE p.Id = @sid;";
            using (var multi = cn.QueryMultiple(sql, new { sid = id }))
            {
                var pessoaFisica = multi.Read<Pessoa, PessoaFisica, Endereco, Pessoa>((p, f, e) => {
                    if(p!=null && pessoaList.Count() == 0)
                    {
                        pessoaList.Add(p);
                        pessoaList[0].PessoaFisica = f;
                    }
                    if(e!= null)
                    {
                        pessoaList[0].PessoaFisica.AdicionarEndereco(e);
                    }
                                         
                    return pessoaList.FirstOrDefault();
                });
                var pessoaJuridica = multi.Read<Pessoa, PessoaJuridica, Endereco, Pessoa>((p, j, e) => {
                    if(p!=null && pessoaList.Count() == 0)
                    {
                        pessoaList.Add(p);
                    }
                    if(!pessoaJuridicaList.Exists(src => src.Id == j.Id))
                    {
                        pessoaJuridicaList.Add(j);
                    }
                    if(j!=null && pessoaJuridicaList.Count() > 0)
                    {                        
                        for (int i = 0; i < pessoaJuridicaList.Count(); i++)
                        {
                            if (pessoaJuridicaList[i].Id == j.Id && e != null)
                            {
                                pessoaJuridicaList[i].AdicionarEndereco(e);
                            }                                                      
                        }
                    } else
                    {
                        j.AdicionarEndereco(e);
                        pessoaJuridicaList.Add(j);
                    }
                    pessoaList[0].PessoaJuridica = pessoaJuridicaList;

                    return pessoaList.FirstOrDefault();

                });
                               
                
            }

            return pessoaList.FirstOrDefault();
        }


        public PessoaFisica ObterEnderecoPorPessoaFisica(Guid id)
        {
            var pessoa = new List<PessoaFisica>();
            var sql = @"SELECT * FROM dbo.Pessoas_Fisicas f
INNER JOIN dbo.PessoaFisicaEndereco x ON f.Id = x.PessoaFisicaId
INNER JOIN dbo.Endereco r ON x.EnderecoId = r.Id
WHERE f.Id = @sid";
            cn.Query<PessoaFisica, Endereco, PessoaFisica>(sql, (f, e) =>
            {

                pessoa.Add(f);
                if (f != null)
                {                    
                    pessoa[0].Enderecos.Add(e);
                }               
                return pessoa.FirstOrDefault();
            }, new { sid = id });

            return pessoa.FirstOrDefault();
        }

        public Pessoa ObterPorIdPessoaFisica(Guid id)
        {
            var pessoa = new List<Pessoa>();
            var sql = @"SELECT * FROM dbo.Pessoa p
            INNER JOIN dbo.Pessoas_Fisicas f ON f.Id = p.Id
            WHERE p.Id = @sid";
            cn.Query<Pessoa, PessoaFisica, Pessoa>(sql, (p, f)=> {
                pessoa.Add(p);
                if (f != null)
                {
                    pessoa[0].PessoaFisica = f;
                }
                return pessoa.FirstOrDefault();

            },new { sid = id });

            return pessoa.FirstOrDefault();
        }

        public PessoaJuridica ObterPorIdPessoaJuridica(Guid id)
        {
            var sql = @"SELECT * FROM dbo.Pessoas_Juridicas p            
            WHERE p.Id = @sid";
            var pessoa = cn.QuerySingle<PessoaJuridica>(sql, new { sid = id });

            return pessoa;
        }

        public PessoaJuridica ObterEnderecoPorPessoaJuridica(Guid id)
        {
            var pessoaJuridica = new List<PessoaJuridica>();
            var sql = @"SELECT * FROM dbo.Pessoas_Juridicas f
LEFT JOIN dbo.PessoaJuridicaEnderecos x ON f.Id = x.PessoaJuridicaId
LEFT JOIN dbo.Endereco r ON x.EnderecoId = r.Id
WHERE f.Id = @sid";
            cn.Query<PessoaJuridica, Endereco, PessoaJuridica>(sql, (j, e) =>
            {

                pessoaJuridica.Add(j);
                if (e != null)
                {
                    pessoaJuridica[0].Enderecos.Add(e);
                }
                return pessoaJuridica.FirstOrDefault();
            }, new { sid = id });

            return pessoaJuridica.FirstOrDefault();
        }

        public Endereco ObterPorIdEndereco(Guid id)
        {
            var sql = @"SELECT * FROM dbo.Endereco e            
            WHERE e.Id = @sid";
            var endereco = cn.QuerySingle<Endereco>(sql, new { sid = id });

            return endereco;
        }


    }
}
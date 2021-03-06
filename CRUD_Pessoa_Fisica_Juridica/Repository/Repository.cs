﻿using CRUD_Pessoa_Fisica_Juridica.Context;
using CRUD_Pessoa_Fisica_Juridica.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;

namespace CRUD_Pessoa_Fisica_Juridica.Repository
{
    public class Repository<TEntity> where TEntity:class
    {
        protected CRUD_Context context;
        protected DbSet<TEntity> dbSet; 
        public Repository()
        {
            context = new CRUD_Context();
            dbSet = context.Set<TEntity>();
        }
        
        public virtual TEntity ObterPorId(Guid id)
        {
            var result = dbSet.Find(id);
            return result;
        }

        public IEnumerable<TEntity> Buscar (Expression<Func<TEntity, bool>> predicate)
        {
            return dbSet.Where(predicate);
        }

        public IEnumerable<TEntity> BuscarComPropriedades(Expression<Func<TEntity,bool>> predicate, string includeProperties = null, string selected = null)
        {
            IQueryable<TEntity> query = dbSet;            

            if (predicate != null)
            {
                query = query.Where(predicate);
            }

            if(includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (selected != null)
                    {
                        query = query.Include(includeProperty).Include(includeProperty + "." + selected);
                    }
                    else
                    {
                        query = query.Include(includeProperty);
                    }

                }
            } 

            return query.ToList();
        }
       
        public void Adicionar(TEntity tentity)
        {
            dbSet.Add(tentity);
            context.SaveChanges();
        }

        public TEntity Atualizar(TEntity tentity, string property = null)
        {
            
            var entry = context.Entry(tentity);
            dbSet.Attach(tentity);
            entry.State = EntityState.Modified;
            context.SaveChanges();
            return tentity;
        }

        public void Remover(Guid id)
        {
            var result = dbSet.Find(id);
            dbSet.Remove(result);
            context.SaveChanges();
        }

        public void Remover(TEntity entity)
        {
            
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<TEntity> ObterTodos(string includeProperties = null)
        {
            IQueryable<TEntity> query = dbSet;
            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.ToList();
        }

    }
}
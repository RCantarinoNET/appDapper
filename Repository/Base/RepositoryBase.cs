using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain.Contracts;
using Domain.Entities;
using Dommel;

namespace Repository.Base
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        private readonly string _conexString;

        protected RepositoryBase()
        {
            _conexString = @"Data Source=.\SQLEXPRESS;Initial Catalog=Dapper_DB;Integrated Security=True";
        }
        public virtual  async Task<IEnumerable<TEntity>> GetAll()
        {
            await using var db = new SqlConnection(_conexString);
            return  db.GetAll<TEntity>();
        }

        public virtual async Task<TEntity> GetById(int id)
        {
            await using var db = new SqlConnection(_conexString);
            return db.Get<TEntity>(id);


        }

        public virtual async Task<TEntity> Insert(TEntity entity)
        {
            await using var db = new SqlConnection(_conexString);
            var id =(int) db.Insert(entity);
            return await GetById(id);
        }

        public virtual async Task<TEntity> Update(TEntity entity)
        {
            await using var db = new SqlConnection(_conexString);
            db.Update(entity);
            return await GetById(entity.Id);
            
        }

        public virtual async Task<bool> Delete(int id)
        {
            await using var db = new SqlConnection(_conexString);
            var entidade = await GetById(id);
            if(entidade == null)
                throw new Exception("Registro não encontrado");

            return await db.DeleteAsync(entidade);
        }

        public  virtual async Task<IEnumerable<TEntity>> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            await using var db = new SqlConnection(_conexString);
            return await db.SelectAsync(predicate);
        }
    }
}
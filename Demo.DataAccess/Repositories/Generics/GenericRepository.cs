using DemoSession3.DataAccess.Data.Contexts;
using DemoSession3.DataAccess.Models;
using DemoSession3.DataAccess.Models.Employees;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoSession3.DataAccess.Repositories.Generics
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly ApplicationDbContext _dbContext;

        public GenericRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // CRUD Operations for Employee

        // Get All
        public IEnumerable<TEntity> GetAll(bool withTracking = false)
        {
            if (withTracking)
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).ToList();
            }
            else
            {
                return _dbContext.Set<TEntity>().Where(T => T.IsDeleted != true).AsNoTracking().ToList();
            }
        }
        public IEnumerable<TResult> GetAll<TResult>(System.Linq.Expressions.Expression<Func<TEntity, TResult>> selector)
        {
            return _dbContext.Set<TEntity>().Where(E => E.IsDeleted != true).Select(selector).ToList();

        }
        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbContext.Set<TEntity>().Where(predicate).ToList();

        }

        // Get By Id
        public TEntity? GetById(int id)
        {
            var entity = _dbContext.Set<TEntity>().Find(id);
            return entity;
        }

        // Insert
        public void Add(TEntity entity)
        {
            _dbContext.Add(entity);
        }

        // Update
        public void Update(TEntity entity)
        {
            _dbContext.Update(entity);
        }

        // Remove
        public void Remove(TEntity entity)
        {
            _dbContext.Remove(entity);
        }


    }
}
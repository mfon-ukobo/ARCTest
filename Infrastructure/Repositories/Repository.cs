using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using Application.Database;
using Application.Repositories;

using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	internal class Repository<TEntity> : IRepository<TEntity> where TEntity : class
	{
		private readonly DbSet<TEntity> _dbSet;

		public Repository(ISQLContext context)
		{
			_dbSet = context.Set<TEntity>();
		}

		public IQueryable<TEntity> Entities => _dbSet;

		public void Add(TEntity entity)
		{
			_dbSet.Add(entity);
		}

		public void AddRange(IEnumerable<TEntity> entities)
		{
			_dbSet.AddRange(entities);
		}

		public void Update(TEntity entity)
		{
			_dbSet.Update(entity);
		}

		public void UpdateRange(IEnumerable<TEntity> entities)
		{
			_dbSet.UpdateRange(entities);
		}

		public void Remove(TEntity entity)
		{
			_dbSet.Remove(entity);
		}

		public void RemoveRange(IEnumerable<TEntity> entities)
		{
			_dbSet.RemoveRange(entities);
		}

		public IQueryable<TEntity> GetBy(Expression<Func<TEntity, bool>> expression)
		{
			var data = _dbSet.Where(expression);

			return data;
		}
	}
}

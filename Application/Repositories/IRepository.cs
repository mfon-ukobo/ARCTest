using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
	public interface IRepository<TEntity> where TEntity : class
	{
		IQueryable<TEntity> Entities { get; }

		void Add(TEntity entity);
		void AddRange(IEnumerable<TEntity> entities);
		IQueryable<TEntity> GetBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> expression);
		void Remove(TEntity entity);
		void RemoveRange(IEnumerable<TEntity> entities);
		void Update(TEntity entity);
		void UpdateRange(IEnumerable<TEntity> entities);
	}
}

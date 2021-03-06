using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace Domain.Pagination
{
	public class PagedList<T> : List<T> where T : class
	{
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public int PageSize { get; private set; }
		public int TotalCount { get; private set; }

		public PaginationMetadata Metadata { get; private set; }

		public bool HasPrevious => CurrentPage > 1;
		public bool HasNext => CurrentPage < TotalPages;

		public PagedList(List<T> items, int count, int pageNumber, int pageSize)
		{
			TotalCount = count;
			PageSize = pageSize;
			CurrentPage = pageNumber;
			TotalPages = (int)Math.Ceiling(count / (double)pageSize);

			Metadata = new PaginationMetadata(TotalCount, PageSize, CurrentPage, TotalPages, HasNext, HasPrevious);

			AddRange(items);
		}

		public static async Task<PagedList<T>> ToPagedListAsync(IQueryable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
			return new PagedList<T>(items, count, pageNumber, pageSize);
		}

		public static PagedList<T> ToPagedList(IEnumerable<T> source, int pageNumber, int pageSize)
		{
			var count = source.Count();
			var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
			return new PagedList<T>(items, count, pageNumber, pageSize);
		}
	}
}

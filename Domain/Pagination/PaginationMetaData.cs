using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Pagination
{
	public class PaginationMetadata
	{
		public PaginationMetadata(int totalCount, int pageSize, int currentPage, int totalPages, bool hasNext, bool hasPrevious)
		{
			TotalCount = totalCount;
			PageSize = pageSize;
			CurrentPage = currentPage;
			TotalPages = totalPages;
			HasNext = hasNext;
			HasPrevious = hasPrevious;
		}

		public int TotalCount { get; private set; }
		public int PageSize { get; private set; }
		public int CurrentPage { get; private set; }
		public int TotalPages { get; private set; }
		public bool HasNext { get; private set; }
		public bool HasPrevious { get; private set; }
	}
}

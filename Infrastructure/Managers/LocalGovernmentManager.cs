using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Application.Managers;
using Application.Repositories;

using Domain.Entities;
using Domain.Pagination;
using Domain.QueryFilters;
using Domain.Results;

namespace Infrastructure.Managers
{
	internal class LocalGovernmentManager : ILocalGovernmentManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public LocalGovernmentManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IQueryable<LocalGovernment> LocalGovernments => _unitOfWork.LocalGovernment.Entities;

		public async Task<ManagerResult> CreateAsync(LocalGovernment localGovernment)
		{
			ArgumentNullException.ThrowIfNull(localGovernment);

			localGovernment.CreatedAt = DateTimeOffset.Now;
			localGovernment.ModifiedAt = DateTimeOffset.Now;

			try
			{
				_unitOfWork.LocalGovernment.Add(localGovernment);
				await _unitOfWork.SaveAsync();

				return ManagerResult.Success;
			}
			catch (Exception)
			{
				// log error
				throw;
			}
		}

		public async Task<PagedList<LocalGovernment>> GetAsync(LocalGovernmentFilterParameters parameters)
		{
			var localGovernments = LocalGovernments;

			if (parameters.StateId.HasValue)
			{
				localGovernments = localGovernments.Where(x => x.StateId == parameters.StateId.Value);
			}

			return await PagedList<LocalGovernment>.ToPagedList(localGovernments, parameters.PageNumber, parameters.PageSize);
		}
	}
}

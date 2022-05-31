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
	internal class StateManager : IStateManager
	{
		private readonly IUnitOfWork _unitOfWork;

		public StateManager(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IQueryable<State> States => _unitOfWork.State.Entities;

		public async Task<ManagerResult> CreateAsync(State state)
		{
			ArgumentNullException.ThrowIfNull(state);

			state.CreatedAt = DateTimeOffset.Now;
			state.ModifiedAt = DateTimeOffset.Now;

			try
			{
				_unitOfWork.State.Add(state);
				await _unitOfWork.SaveAsync();

				return ManagerResult.Success;
			}
			catch (Exception)
			{
				// TODO: log error
				throw;
			}
		}

		public async Task<PagedList<State>> GetAsync(StateFilterParameters parameters)
		{
			return await PagedList<State>.ToPagedListAsync(States, parameters.PageNumber, parameters.PageSize);
		}
	}
}

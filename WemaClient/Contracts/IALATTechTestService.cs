using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WemaClient.Models;

namespace WemaClient.Contracts
{
	public interface IALATTechTestService
	{
		Task<ApiResponse<IEnumerable<Bank>>> GetBanks();
	}
}

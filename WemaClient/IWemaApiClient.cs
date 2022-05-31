using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WemaClient.Contracts;

namespace WemaClient
{
	public interface IWemaApiClient
	{
		IALATTechTestService ALATTechTest { get; }
	}
}

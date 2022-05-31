using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
	public class LocalGovernmentStateMismatchException : Exception
	{
		public LocalGovernmentStateMismatchException(string? message) : base(message)
		{
		}

		public LocalGovernmentStateMismatchException(long localGovernmentId, long stateId) : base($"The Local Government: {localGovernmentId} does not belong to the State: {stateId}")
		{
		}
	}
}

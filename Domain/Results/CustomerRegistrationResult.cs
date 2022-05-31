
using Domain.Enums;

namespace Domain.Results
{
	public class CustomerRegistrationResult : ServiceResult
	{
		public RegistrationStatus Status { get; init; }
		public string Token { get; init; }

		public static new CustomerRegistrationResult Failure(IEnumerable<string> messages) => new CustomerRegistrationResult
		{
			Succeeded = false,
			Errors = new List<string>(messages)
		};

		public static new CustomerRegistrationResult Failure(string message) => Failure(new string[] { message });

		public static new CustomerRegistrationResult Success(RegistrationStatus status, string token)
		{
			return new CustomerRegistrationResult
			{
				Succeeded = true,
				Status = status,
				Token = token
			};
		}
	}
}

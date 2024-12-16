namespace Universal.Common
{
	public class UserResponse : Response<UserResponse>
	{
		public UserResponse()
		{






		}

		public string Email { get; set; } = String.Empty;
		public string Password { get; set; } = String.Empty;
	}
}
namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserNetworkController : ControllerBase
	{
		readonly IUserNetworkService Service;

		public UserNetworkController(IUserNetworkService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/usernetwork")]
		public async Task<Response<UserNetworkResponse>> Create([FromBody] UserNetworkRegisterDto Model)
		{
			Response<UserNetworkResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserNetworkResponse>
			{
				Data = Response.Data
			};
		}
	}
}
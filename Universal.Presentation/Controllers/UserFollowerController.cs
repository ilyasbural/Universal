namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserFollowerController : ControllerBase
	{
		readonly IUserFollowerService Service;

		public UserFollowerController(IUserFollowerService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userfollower")]
		public async Task<Response<UserFollowerResponse>> Create([FromBody] UserFollowerRegisterDto Model)
		{
			Response<UserFollowerResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserFollowerResponse>
			{
				Data = Response.Data
			};
		}
	}
}
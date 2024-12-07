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

		[HttpPut]
		[Route("api/userfollower")]
		public async Task<Response<UserFollowerResponse>> Update([FromBody] UserFollowerUpdateDto Model)
		{
			Response<UserFollowerResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserFollowerResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userfollower")]
		public async Task<Response<UserFollowerResponse>> Delete([FromBody] UserFollowerDeleteDto Model)
		{
			Response<UserFollowerResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserFollowerResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userfollower")]
		public async Task<Response<UserFollowerResponse>> Get([FromQuery] UserFollowerSelectDto Model)
		{
			Response<UserFollowerResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserFollowerResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/userfollowersingle")]
		public async Task<Response<UserFollowerResponse>> GetSingle([FromQuery] UserFollowerSelectDto Model)
		{
			Response<UserFollowerResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserFollowerResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
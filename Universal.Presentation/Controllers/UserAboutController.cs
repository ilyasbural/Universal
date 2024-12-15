namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserAboutController : ControllerBase
	{
		readonly IUserAboutService Service;
		public UserAboutController(IUserAboutService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userabout")]
		public async Task<Response<UserAboutResponse>> Create([FromBody] UserAboutRegisterDto Model)
		{
			Response<UserAboutResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserAboutResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/userabout")]
		public async Task<Response<UserAboutResponse>> Update([FromBody] UserAboutUpdateDto Model)
		{
			Response<UserAboutResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserAboutResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userabout")]
		public async Task<Response<UserAboutResponse>> Delete([FromBody] UserAboutDeleteDto Model)
		{
			Response<UserAboutResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserAboutResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userabout")]
		public async Task<Response<UserAboutResponse>> Get([FromQuery] UserAboutSelectDto Model)
		{
			Response<UserAboutResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserAboutResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/useraboutsingle")]
		public async Task<Response<UserAboutResponse>> GetSingle([FromQuery] UserAboutSelectDto Model)
		{
			Response<UserAboutResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserAboutResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
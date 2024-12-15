namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserSettingsController : ControllerBase
	{
		readonly IUserSettingsService Service;
		public UserSettingsController(IUserSettingsService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/usersettings")]
		public async Task<Response<UserSettingsResponse>> Create([FromBody] UserSettingsRegisterDto Model)
		{
			Response<UserSettingsResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserSettingsResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/usersettings")]
		public async Task<Response<UserSettingsResponse>> Update([FromBody] UserSettingsUpdateDto Model)
		{
			Response<UserSettingsResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserSettingsResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/usersettings")]
		public async Task<Response<UserSettingsResponse>> Delete([FromBody] UserSettingsDeleteDto Model)
		{
			Response<UserSettingsResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserSettingsResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/usersettings")]
		public async Task<Response<UserSettingsResponse>> Get([FromQuery] UserSettingsSelectDto Model)
		{
			Response<UserSettingsResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserSettingsResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/usersettingssingle")]
		public async Task<Response<UserSettingsResponse>> GetSingle([FromQuery] UserSettingsSelectDto Model)
		{
			Response<UserSettingsResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserSettingsResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
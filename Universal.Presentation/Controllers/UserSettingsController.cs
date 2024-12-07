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
	}
}
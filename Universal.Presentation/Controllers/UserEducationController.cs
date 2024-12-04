namespace Universal.Presentation.Controllers
{
    using Core;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    public class UserEducationController : ControllerBase
    {
        readonly IUserSettingsService Service;

        public UserEducationController(IUserSettingsService service)
        {
            Service = service;
        }

		[HttpPost]
		[Authorize]
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
		[Authorize]
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
		[Authorize]
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
		[Authorize]
		[Route("api/usersettings")]
		public async Task<Response<UserSettingsResponse>> Get([FromQuery] UserSettingsSelectDto Model)
		{
			Response<UserSettingsResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserSettingsResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
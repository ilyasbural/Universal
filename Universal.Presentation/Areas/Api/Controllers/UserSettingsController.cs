namespace Universal.Api.Controllers
{
    using Core;
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
        public async Task<Response<UserSettings>> Create([FromBody] UserSettingsRegisterDto Model)
        {
            Response<UserSettings> Response = await Service.InsertAsync(Model);
            return new Response<UserSettings>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/usersettings")]
        public async Task<Response<UserSettings>> Update([FromBody] UserSettingsUpdateDto Model)
        {
            Response<UserSettings> Response = await Service.UpdateAsync(Model);
            return new Response<UserSettings>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/usersettings")]
        public async Task<Response<UserSettings>> Delete([FromBody] UserSettingsDeleteDto Model)
        {
            Response<UserSettings> Response = await Service.DeleteAsync(Model);
            return new Response<UserSettings>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usersettings")]
        public async Task<Response<UserSettings>> Get()
        {
            Response<UserSettings> Response = await Service.SelectAsync(new UserSettingsSelectDto { });
            return new Response<UserSettings>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usersettingssingle")]
        public async Task<Response<UserSettings>> Get([FromQuery] UserSettingsSelectDto Model)
        {
            Response<UserSettings> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserSettings>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
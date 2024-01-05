namespace Universal.Api.Controllers
{
    using Core;
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
        public async Task<Response<UserAbout>> Create([FromBody] UserAboutRegisterDto Model)
        {
            Response<UserAbout> Response = await Service.InsertAsync(Model);
            return new Response<UserAbout>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userabout")]
        public async Task<Response<UserAbout>> Update([FromBody] UserAboutUpdateDto Model)
        {
            Response<UserAbout> Response = await Service.UpdateAsync(Model);
            return new Response<UserAbout>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userabout")]
        public async Task<Response<UserAbout>> Delete([FromBody] UserAboutDeleteDto Model)
        {
            Response<UserAbout> Response = await Service.DeleteAsync(Model);
            return new Response<UserAbout>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userabout")]
        public async Task<Response<UserAbout>> Get()
        {
            Response<UserAbout> Response = await Service.SelectAsync(new UserAbilitySelectDto { });
            return new Response<UserAbout>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/useraboutsingle")]
        public async Task<Response<UserAbout>> Get([FromQuery] UserAbilitySelectDto Model)
        {
            Response<UserAbout> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserAbout>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
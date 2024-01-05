namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserAbilityController : ControllerBase
    {
        readonly IUserAbilityService Service;
        public UserAbilityController(IUserAbilityService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userability")]
        public async Task<Response<UserAbility>> Create([FromBody] UserAbilityRegisterDto Model)
        {
            Response<UserAbility> Response = await Service.InsertAsync(Model);
            return new Response<UserAbility>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userability")]
        public async Task<Response<UserAbility>> Update([FromBody] UserAbilityUpdateDto Model)
        {
            Response<UserAbility> Response = await Service.UpdateAsync(Model);
            return new Response<UserAbility>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userability")]
        public async Task<Response<UserAbility>> Delete([FromBody] UserAbilityDeleteDto Model)
        {
            Response<UserAbility> Response = await Service.DeleteAsync(Model);
            return new Response<UserAbility>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userability")]
        public async Task<Response<UserAbility>> Get()
        {
            Response<UserAbility> Response = await Service.SelectAsync(new UserAbilitySelectDto { });
            return new Response<UserAbility>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userabilitysingle")]
        public async Task<Response<UserAbility>> Get([FromQuery] UserAbilitySelectDto Model)
        {
            Response<UserAbility> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserAbility>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
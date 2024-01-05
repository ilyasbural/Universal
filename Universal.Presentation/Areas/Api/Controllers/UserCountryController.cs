namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserCountryController : ControllerBase
    {
        readonly IUserCountryService Service;
        public UserCountryController(IUserCountryService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/usercountry")]
        public async Task<Response<UserCountry>> Create([FromBody] UserCountryRegisterDto Model)
        {
            Response<UserCountry> Response = await Service.InsertAsync(Model);
            return new Response<UserCountry>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/usercountry")]
        public async Task<Response<UserCountry>> Update([FromBody] UserCountryUpdateDto Model)
        {
            Response<UserCountry> Response = await Service.UpdateAsync(Model);
            return new Response<UserCountry>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/usercountry")]
        public async Task<Response<UserCountry>> Delete([FromBody] UserCountryDeleteDto Model)
        {
            Response<UserCountry> Response = await Service.DeleteAsync(Model);
            return new Response<UserCountry>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usercountry")]
        public async Task<Response<UserCountry>> Get()
        {
            Response<UserCountry> Response = await Service.SelectAsync(new UserCountrySelectDto { });
            return new Response<UserCountry>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usercountrysingle")]
        public async Task<Response<UserCountry>> Get([FromQuery] UserCountrySelectDto Model)
        {
            Response<UserCountry> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserCountry>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
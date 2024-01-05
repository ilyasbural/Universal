namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserReferanceController : ControllerBase
    {
        readonly IUserReferanceService Service;
        public UserReferanceController(IUserReferanceService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userreferance")]
        public async Task<Response<UserReferance>> Create([FromBody] UserReferanceRegisterDto Model)
        {
            Response<UserReferance> Response = await Service.InsertAsync(Model);
            return new Response<UserReferance>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userreferance")]
        public async Task<Response<UserReferance>> Update([FromBody] UserReferanceUpdateDto Model)
        {
            Response<UserReferance> Response = await Service.UpdateAsync(Model);
            return new Response<UserReferance>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userreferance")]
        public async Task<Response<UserReferance>> Delete([FromBody] UserReferanceDeleteDto Model)
        {
            Response<UserReferance> Response = await Service.DeleteAsync(Model);
            return new Response<UserReferance>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userreferance")]
        public async Task<Response<UserReferance>> Get()
        {
            Response<UserReferance> Response = await Service.SelectAsync(new UserReferanceSelectDto { });
            return new Response<UserReferance>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userreferancesingle")]
        public async Task<Response<UserReferance>> Get([FromQuery] UserReferanceSelectDto Model)
        {
            Response<UserReferance> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserReferance>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
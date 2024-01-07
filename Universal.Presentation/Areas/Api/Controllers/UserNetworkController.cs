namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class UserNetworkController : ControllerBase
    {
        readonly IUserNetworkService Service;
        public UserNetworkController(IUserNetworkService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/usernetwork")]
        public async Task<Response<UserNetwork>> Create([FromBody] UserNetworkRegisterDto Model)
        {
            Response<UserNetwork> Response = await Service.InsertAsync(Model);
            return new Response<UserNetwork>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/usernetwork")]
        public async Task<Response<UserNetwork>> Update([FromBody] UserNetworkUpdateDto Model)
        {
            Response<UserNetwork> Response = await Service.UpdateAsync(Model);
            return new Response<UserNetwork>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/usernetwork")]
        public async Task<Response<UserNetwork>> Delete([FromBody] UserNetworkDeleteDto Model)
        {
            Response<UserNetwork> Response = await Service.DeleteAsync(Model);
            return new Response<UserNetwork>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usernetwork")]
        public async Task<Response<UserNetwork>> Get()
        {
            Response<UserNetwork> Response = await Service.SelectAsync(new UserNetworkSelectDto { });
            return new Response<UserNetwork>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usernetworksingle")]
        public async Task<Response<UserNetwork>> Get([FromQuery] UserNetworkSelectDto Model)
        {
            Response<UserNetwork> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserNetwork>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
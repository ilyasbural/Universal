namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class NetworkController : ControllerBase
    {
        readonly INetworkService Service;
        public NetworkController(INetworkService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/network")]
        public async Task<Response<Network>> Create([FromBody] NetworkRegisterDto Model)
        {
            Response<Network> Response = await Service.InsertAsync(Model);
            return new Response<Network>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/network")]
        public async Task<Response<Network>> Update([FromBody] NetworkUpdateDto Model)
        {
            Response<Network> Response = await Service.UpdateAsync(Model);
            return new Response<Network>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/network")]
        public async Task<Response<Network>> Delete([FromBody] NetworkDeleteDto Model)
        {
            Response<Network> Response = await Service.DeleteAsync(Model);
            return new Response<Network>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/network")]
        public async Task<Response<Network>> Get()
        {
            Response<Network> Response = await Service.SelectAsync(new NetworkSelectDto { });
            return new Response<Network>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networksingle")]
        public async Task<Response<Network>> Get([FromQuery] NetworkSelectDto Model)
        {
            Response<Network> Response = await Service.SelectSingleAsync(Model);
            return new Response<Network>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
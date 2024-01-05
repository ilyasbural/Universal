namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class NetworkActionController : ControllerBase
    {
        readonly INetworkActionService Service;
        public NetworkActionController(INetworkActionService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/networkaction")]
        public async Task<Response<NetworkAction>> Create([FromBody] NetworkActionRegisterDto Model)
        {
            Response<NetworkAction> Response = await Service.InsertAsync(Model);
            return new Response<NetworkAction>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/networkaction")]
        public async Task<Response<NetworkAction>> Update([FromBody] NetworkActionUpdateDto Model)
        {
            Response<NetworkAction> Response = await Service.UpdateAsync(Model);
            return new Response<NetworkAction>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/networkaction")]
        public async Task<Response<NetworkAction>> Delete([FromBody] NetworkActionDeleteDto Model)
        {
            Response<NetworkAction> Response = await Service.DeleteAsync(Model);
            return new Response<NetworkAction>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networkaction")]
        public async Task<Response<NetworkAction>> Get()
        {
            Response<NetworkAction> Response = await Service.SelectAsync(new NetworkActionSelectDto { });
            return new Response<NetworkAction>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networkactionsingle")]
        public async Task<Response<NetworkAction>> Get([FromQuery] NetworkActionSelectDto Model)
        {
            Response<NetworkAction> Response = await Service.SelectSingleAsync(Model);
            return new Response<NetworkAction>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
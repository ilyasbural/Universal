namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class NetworkDetailController : ControllerBase
    {
        readonly INetworkDetailService Service;
        public NetworkDetailController(INetworkDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/networkdetail")]
        public async Task<Response<NetworkDetail>> Create([FromBody] NetworkDetailRegisterDto Model)
        {
            Response<NetworkDetail> Response = await Service.InsertAsync(Model);
            return new Response<NetworkDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/networkdetail")]
        public async Task<Response<NetworkDetail>> Update([FromBody] NetworkDetailUpdateDto Model)
        {
            Response<NetworkDetail> Response = await Service.UpdateAsync(Model);
            return new Response<NetworkDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/networkdetail")]
        public async Task<Response<NetworkDetail>> Delete([FromBody] NetworkDetailDeleteDto Model)
        {
            Response<NetworkDetail> Response = await Service.DeleteAsync(Model);
            return new Response<NetworkDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networkdetail")]
        public async Task<Response<NetworkDetail>> Get()
        {
            Response<NetworkDetail> Response = await Service.SelectAsync(new NetworkDetailSelectDto { });
            return new Response<NetworkDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networkdetailsingle")]
        public async Task<Response<NetworkDetail>> Get([FromQuery] NetworkDetailSelectDto Model)
        {
            Response<NetworkDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<NetworkDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
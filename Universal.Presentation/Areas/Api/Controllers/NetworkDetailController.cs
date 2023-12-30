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

        //[HttpPut]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Update([FromBody] AbilityUpdateDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.UpdateAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Delete([FromBody] AbilityDeleteDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.DeleteAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/networkdetail")]
        public async Task<Response<NetworkDetail>> Get()
        {
            Response<NetworkDetail> Response = await Service.SelectAsync();
            return new Response<NetworkDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/ability/{id}")]
        //public async Task<AbilityWebResponse> Get([FromBody] AbilityAnyDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.AnySelectAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}
    }
}
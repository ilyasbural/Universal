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
        [Route("api/networkaction")]
        public async Task<Response<NetworkAction>> Get()
        {
            Response<NetworkAction> Response = await Service.SelectAsync();
            return new Response<NetworkAction>
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
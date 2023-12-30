namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        //[HttpPut]
        //[Route("api/usernetwork")]
        //public async Task<AbilityWebResponse> Update([FromBody] AbilityUpdateDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.UpdateAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/usernetwork")]
        //public async Task<AbilityWebResponse> Delete([FromBody] AbilityDeleteDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.DeleteAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/usernetwork")]
        public async Task<Response<UserNetwork>> Get()
        {
            Response<UserNetwork> Response = await Service.SelectAsync();
            return new Response<UserNetwork>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/usernetwork/{id}")]
        //public async Task<AbilityWebResponse> Get([FromBody] AbilityAnyDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.AnySelectAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}
    }
}
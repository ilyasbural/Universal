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
        [Route("api/userreferance")]
        public async Task<Response<UserReferance>> Get()
        {
            Response<UserReferance> Response = await Service.SelectAsync();
            return new Response<UserReferance>
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
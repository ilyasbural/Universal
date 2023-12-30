namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserProjectController : ControllerBase
    {
        readonly IUserProjectService Service;
        public UserProjectController(IUserProjectService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userproject")]
        public async Task<Response<UserProject>> Create([FromBody] UserProjectRegisterDto Model)
        {
            Response<UserProject> Response = await Service.InsertAsync(Model);
            return new Response<UserProject>
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
        [Route("api/userproject")]
        public async Task<Response<UserProject>> Get()
        {
            Response<UserProject> Response = await Service.SelectAsync();
            return new Response<UserProject>
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
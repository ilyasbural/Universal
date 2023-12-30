namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CompanyFollowerController : ControllerBase
    {
        readonly ICompanyFollowerService Service;
        public CompanyFollowerController(ICompanyFollowerService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollower>> Create([FromBody] CompanyFollowerRegisterDto Model)
        {
            Response<CompanyFollower> Response = await Service.InsertAsync(Model);
            return new Response<CompanyFollower>
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
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollower>> Get()
        {
            Response<CompanyFollower> Response = await Service.SelectAsync();
            return new Response<CompanyFollower>
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
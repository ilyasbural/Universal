namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CompanyDetailController : ControllerBase
    {
        readonly ICompanyDetailService Service;
        public CompanyDetailController(ICompanyDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/companydetail")]
        public async Task<Response<CompanyDetail>> Create([FromBody] CompanyDetailRegisterDto Model)
        {
            Response<CompanyDetail> Response = await Service.InsertAsync(Model);
            return new Response<CompanyDetail>
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
        [Route("api/companydetail")]
        public async Task<Response<CompanyDetail>> Get()
        {
            Response<CompanyDetail> Response = await Service.SelectAsync();
            return new Response<CompanyDetail>
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
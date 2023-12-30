namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CompanyAboutController : ControllerBase
    {
        readonly ICompanyAboutService Service;
        public CompanyAboutController(ICompanyAboutService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/companyabout")]
        public async Task<Response<CompanyAbout>> Create([FromBody] CompanyAboutRegisterDto Model)
        {
            Response<CompanyAbout> Response = await Service.InsertAsync(Model);
            return new Response<CompanyAbout>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        //[HttpPut]
        //[Route("api/companyabout")]
        //public async Task<CompanyAboutWebResponse> Update([FromBody] CompanyAboutUpdateDataTransfer Model)
        //{
        //    CompanyAboutServiceResponse companyAboutServiceResponse = await Service.UpdateAsync(Model);
        //    return new CompanyAboutWebResponse
        //    {
        //        Single = companyAboutServiceResponse.Single,
        //        Success = companyAboutServiceResponse.Success
        //    };
        //}

        //[HttpDelete]
        //[Route("api/companyabout")]
        //public async Task<CompanyAboutWebResponse> Delete([FromBody] CompanyAboutDeleteDataTransfer Model)
        //{
        //    CompanyAboutServiceResponse companyAboutServiceResponse = await Service.DeleteAsync(Model);
        //    return new CompanyAboutWebResponse
        //    {
        //        Single = companyAboutServiceResponse.Single,
        //        Success = companyAboutServiceResponse.Success
        //    };
        //}

        [HttpGet]
        [Route("api/companyabout")]
        public async Task<Response<CompanyAbout>> Get()
        {
            Response<CompanyAbout> Response = await Service.SelectAsync();
            return new Response<CompanyAbout>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/companyabout/{id}")]
        //public async Task<CompanyAboutWebResponse> Get([FromBody] CompanyAboutAnyDataTransfer Model)
        //{
        //    CompanyAboutServiceResponse companyAboutServiceResponse = await Service.AnySelectAsync(Model);
        //    return new CompanyAboutWebResponse
        //    {
        //        Success = companyAboutServiceResponse.Success
        //    };
        //}
    }
}
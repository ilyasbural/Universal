namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CompanyController : ControllerBase
    {
        readonly ICompanyService Service;
        public CompanyController(ICompanyService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/company")]
        public async Task<Response<Company>> Create([FromBody] CompanyRegisterDto Model)
        {
            Response<Company> Response = await Service.InsertAsync(Model);
            return new Response<Company>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/company")]
        public async Task<Response<Company>> Update([FromBody] CompanyUpdateDto Model)
        {
            Response<Company> Response = await Service.UpdateAsync(Model);
            return new Response<Company>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/company")]
        public async Task<Response<Company>> Delete([FromBody] CompanyDeleteDto Model)
        {
            Response<Company> Response = await Service.DeleteAsync(Model);
            return new Response<Company>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/company")]
        public async Task<Response<Company>> Get()
        {
            Response<Company> Response = await Service.SelectAsync(new CompanySelectDto { });
            return new Response<Company>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/company/{id}")]
        //public async Task<CompanyWebResponse> Get([FromBody] CompanyAnyDataTransfer Model)
        //{
        //    CompanyServiceResponse companyServiceResponse = await Service.AnySelectAsync(Model);
        //    return new CompanyWebResponse
        //    {
        //        Success = companyServiceResponse.Success
        //    };
        //}
    }
}
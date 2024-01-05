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

        [HttpPut]
        [Route("api/companydetail")]
        public async Task<Response<CompanyDetail>> Update([FromBody] CompanyDetailUpdateDto Model)
        {
            Response<CompanyDetail> Response = await Service.UpdateAsync(Model);
            return new Response<CompanyDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/companydetail")]
        public async Task<Response<CompanyDetail>> Delete([FromBody] CompanyDetailDeleteDto Model)
        {
            Response<CompanyDetail> Response = await Service.DeleteAsync(Model);
            return new Response<CompanyDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/companydetail")]
        public async Task<Response<CompanyDetail>> Get()
        {
            Response<CompanyDetail> Response = await Service.SelectAsync(new CompanyDetailSelectDto { });
            return new Response<CompanyDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/companydetailsingle")]
        public async Task<Response<CompanyDetail>> Get([FromQuery] CompanyDetailSelectDto Model)
        {
            Response<CompanyDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<CompanyDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
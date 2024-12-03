namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CompanyController : ControllerBase
    {
        readonly IOrganizationIncomeService Service;

        public CompanyController(IOrganizationIncomeService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationincome")]
        public async Task<Response<OrganizationIncomeResponse>> Create([FromBody] OrganizationIncomeRegisterDto Model)
        {
            Response<OrganizationIncomeResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationIncomeResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationincome")]
        public async Task<Response<OrganizationIncomeResponse>> Update([FromBody] OrganizationIncomeUpdateDto Model)
        {
            Response<OrganizationIncomeResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationIncomeResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationincome")]
        public async Task<Response<OrganizationIncomeResponse>> Delete([FromBody] OrganizationIncomeDeleteDto Model)
        {
            Response<OrganizationIncomeResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationIncomeResponse>
            {
                Data = Response.Data
            };
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationincome")]
        //public async Task<Response<OrganizationIncome>> Get([FromQuery] OrganizationIncomeSelectDto Model)
        //{
        //    Response<OrganizationIncome> Response = await Service.SelectAsync(Model);
        //    return new Response<OrganizationIncome>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationincomeorganizationid")]
        //public async Task<Response<OrganizationIncome>> GetOrganizationIncome([FromQuery] OrganizationIncomeSelectDto Model)
        //{
        //    Response<OrganizationIncome> Response = await Service.SelectOrganizationIncomeAsync(Model);
        //    return new Response<OrganizationIncome>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationincomesingle")]
        //public async Task<Response<OrganizationIncome>> GetSingle([FromQuery] OrganizationIncomeSelectDto Model)
        //{
        //    Response<OrganizationIncome> Response = await Service.SelectSingleAsync(Model);
        //    return new Response<OrganizationIncome>
        //    {
        //        Collection = Response.Collection
        //    };
        //}
    }
}
namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CountryController : ControllerBase
    {
        readonly IOrganizationShareService Service;

        public CountryController(IOrganizationShareService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationshare")]
        public async Task<Response<OrganizationShareResponse>> Create([FromBody] OrganizationShareRegisterDto Model)
        {
            Response<OrganizationShareResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationShareResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationshare")]
        public async Task<Response<OrganizationShareResponse>> Update([FromBody] OrganizationShareUpdateDto Model)
        {
            Response<OrganizationShareResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationShareResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationshare")]
        public async Task<Response<OrganizationShareResponse>> Delete([FromBody] OrganizationShareDeleteDto Model)
        {
            Response<OrganizationShareResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationShareResponse>
            {
                Data = Response.Data
            };
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationshare")]
        //public async Task<Response<OrganizationShare>> Get([FromQuery] OrganizationShareSelectDto Model)
        //{
        //    Response<OrganizationShare> Response = await Service.SelectAsync(Model);
        //    return new Response<OrganizationShare>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationsharesingle")]
        //public async Task<Response<OrganizationShare>> GetSingle([FromQuery] OrganizationShareSelectDto Model)
        //{
        //    Response<OrganizationShare> Response = await Service.SelectSingleAsync(Model);
        //    return new Response<OrganizationShare>
        //    {
        //        Collection = Response.Collection
        //    };
        //}
    }
}
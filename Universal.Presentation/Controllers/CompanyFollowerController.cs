namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CompanyFollowerController : ControllerBase
    {
        readonly IOrganizationSettingsService Service;

        public CompanyFollowerController(IOrganizationSettingsService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationsettings")]
        public async Task<Response<OrganizationSettingsResponse>> Create([FromBody] OrganizationSettingsRegisterDto Model)
        {
            Response<OrganizationSettingsResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationSettingsResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationsettings")]
        public async Task<Response<OrganizationSettingsResponse>> Update([FromBody] OrganizationSettingsUpdateDto Model)
        {
            Response<OrganizationSettingsResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationSettingsResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationsettings")]
        public async Task<Response<OrganizationSettingsResponse>> Delete([FromBody] OrganizationSettingsDeleteDto Model)
        {
            Response<OrganizationSettingsResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationSettingsResponse>
            {
                Data = Response.Data
            };
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationsettings")]
        //public async Task<Response<OrganizationSettings>> Get([FromQuery] OrganizationSettingsSelectDto Model)
        //{
        //    Response<OrganizationSettings> Response = await Service.SelectAsync(Model);
        //    return new Response<OrganizationSettings>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationsettingssingle")]
        //public async Task<Response<OrganizationSettings>> GetSingle([FromQuery] OrganizationSettingsSelectDto Model)
        //{
        //    Response<OrganizationSettings> Response = await Service.SelectSingleAsync(Model);
        //    return new Response<OrganizationSettings>
        //    {
        //        Collection = Response.Collection
        //    };
        //}
    }
}
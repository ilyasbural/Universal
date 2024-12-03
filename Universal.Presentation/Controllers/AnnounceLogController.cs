namespace Universal.Presentation.Controllers
{
    using Core;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    public class AnnounceLogController : ControllerBase
    {
        readonly IOrganizationService Service;

        public AnnounceLogController(IOrganizationService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organization")]
        public async Task<Response<OrganizationResponse>> Create([FromBody] OrganizationRegisterDto Model)
        {
            Response<OrganizationResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organization")]
        public async Task<Response<OrganizationResponse>> Update([FromBody] OrganizationUpdateDto Model)
        {
            Response<OrganizationResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organization")]
        public async Task<Response<OrganizationResponse>> Delete([FromBody] OrganizationDeleteDto Model)
        {
            Response<OrganizationResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organization")]
        public async Task<Response<OrganizationResponse>> Get([FromQuery] OrganizationSelectDto Model)
        {
            Response<OrganizationResponse> Response = await Service.SelectAsync(Model);
            return new Response<OrganizationResponse>
            {
                DataSource = Response.DataSource
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationsingle")]
        public async Task<Response<OrganizationResponse>> GetSingle([FromQuery] OrganizationSelectDto Model)
        {
            Response<OrganizationResponse> Response = await Service.SelectSingleAsync(Model);
            return new Response<OrganizationResponse>
            {
                DataSource = Response.DataSource
            };
        }

		[HttpGet]
		[Authorize]
		[Route("api/organizationcount")]
		public async Task<Response<OrganizationResponse>> GetCount([FromQuery] OrganizationSelectDto Model)
		{
			Response<OrganizationResponse> Response = await Service.SelectCountAsync(Model);
			return new Response<OrganizationResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
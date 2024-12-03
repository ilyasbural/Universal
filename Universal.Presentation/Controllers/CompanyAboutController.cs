namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CompanyAboutController : ControllerBase
    {
        readonly IOrganizationInvitationService Service;

        public CompanyAboutController(IOrganizationInvitationService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationinvitation")]
        public async Task<Response<OrganizationInvitationResponse>> Create([FromBody] OrganizationInvitationRegisterDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationInvitationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationinvitation")]
        public async Task<Response<OrganizationInvitationResponse>> Update([FromBody] OrganizationInvitationUpdateDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationInvitationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationinvitation")]
        public async Task<Response<OrganizationInvitationResponse>> Delete([FromBody] OrganizationInvitationDeleteDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationInvitationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationconfirmation")]
        public async Task<Response<OrganizationInvitationResponse>> OrganizationConfirmation([FromBody] OrganizationInvitationConfirmationDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.Confirmation(Model);
            return new Response<OrganizationInvitationResponse>
            {
                Data = Response.Data
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationinvitation")]
        public async Task<Response<OrganizationInvitationResponse>> Get([FromQuery] OrganizationInvitationSelectDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.SelectAsync(Model);
            return new Response<OrganizationInvitationResponse>
            {
                DataSource = Response.DataSource
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationinvitationforuser")]
        public async Task<Response<OrganizationInvitationResponse>> GetUsers([FromQuery] OrganizationInvitationSelectDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.SelectUsersAsync(Model);
            return new Response<OrganizationInvitationResponse>
            {
                DataSource = Response.DataSource
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationinvitationsingle")]
        public async Task<Response<OrganizationInvitationResponse>> GetSingle([FromQuery] OrganizationInvitationSelectDto Model)
        {
            Response<OrganizationInvitationResponse> Response = await Service.SelectSingleAsync(Model);
            return new Response<OrganizationInvitationResponse>
            {
                DataSource = Response.DataSource
            };
        }
    }
}
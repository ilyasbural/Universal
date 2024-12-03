namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class EmojiController : ControllerBase
    {
        readonly IOrganizationUserService Service;

        public EmojiController(IOrganizationUserService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationuser")]
        public async Task<Response<OrganizationUserResponse>> Create([FromBody] OrganizationUserRegisterDto Model)
        {
            Response<OrganizationUserResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationUserResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationuser")]
        public async Task<Response<OrganizationUserResponse>> Update([FromBody] OrganizationUserUpdateDto Model)
        {
            Response<OrganizationUserResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationUserResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationuser")]
        public async Task<Response<OrganizationUserResponse>> Delete([FromBody] OrganizationUserDeleteDto Model)
        {
            Response<OrganizationUserResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationUserResponse>
            {
                Data = Response.Data
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationuser")]
        public async Task<Response<OrganizationUserResponse>> Get([FromQuery] OrganizationUserSelectDto Model)
        {
            Response<OrganizationUserResponse> Response = await Service.SelectAsync(Model);
            return new Response<OrganizationUserResponse>
            {
                DataSource = Response.DataSource
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationuserfororganization")]
        public async Task<Response<OrganizationUserResponse>> GetOrganization([FromQuery] OrganizationUserSelectDto Model)
        {
            Response<OrganizationUserResponse> Response = await Service.SelectOrganizationAsync(Model);
            return new Response<OrganizationUserResponse>
            {
                DataSource = Response.DataSource
            };
        }
    }
}
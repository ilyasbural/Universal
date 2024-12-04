namespace Universal.Presentation.Controllers
{
	using Core;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
	public class AnnounceDetailController : ControllerBase
	{
		readonly IOrganizationCommentService Service;

		public AnnounceDetailController(IOrganizationCommentService service)
		{
			Service = service;
		}

		[HttpPost]
		[Authorize]
		[Route("api/organizationcomment")]
		public async Task<Response<OrganizationCommentResponse>> Create([FromBody] OrganizationCommentRegisterDto Model)
		{
			Response<OrganizationCommentResponse> Response = await Service.InsertAsync(Model);
			return new Response<OrganizationCommentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/organizationcomment")]
		public async Task<Response<OrganizationCommentResponse>> Update([FromBody] OrganizationCommentUpdateDto Model)
		{
			Response<OrganizationCommentResponse> Response = await Service.UpdateAsync(Model);
			return new Response<OrganizationCommentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/organizationcomment")]
		public async Task<Response<OrganizationCommentResponse>> Delete([FromBody] OrganizationCommentDeleteDto Model)
		{
			Response<OrganizationCommentResponse> Response = await Service.DeleteAsync(Model);
			return new Response<OrganizationCommentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/organizationcomment")]
		public async Task<Response<OrganizationCommentResponse>> Get([FromQuery] OrganizationCommentSelectDto Model)
		{
			Response<OrganizationCommentResponse> Response = await Service.SelectAsync(Model);
			return new Response<OrganizationCommentResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/organizationcommentsingle")]
		public async Task<Response<OrganizationCommentResponse>> GetSingle([FromQuery] OrganizationCommentSelectDto Model)
		{
			Response<OrganizationCommentResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<OrganizationCommentResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
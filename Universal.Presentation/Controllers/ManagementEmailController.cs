namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class ManagementEmailController : ControllerBase
	{
		readonly IManagementEmailService Service;
		public ManagementEmailController(IManagementEmailService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/managementemail")]
		public async Task<Response<ManagementEmailResponse>> Create([FromBody] ManagementEmailRegisterDto Model)
		{
			Response<ManagementEmailResponse> Response = await Service.InsertAsync(Model);
			return new Response<ManagementEmailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/managementemail")]
		public async Task<Response<ManagementEmailResponse>> Update([FromBody] ManagementEmailUpdateDto Model)
		{
			Response<ManagementEmailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<ManagementEmailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/managementemail")]
		public async Task<Response<ManagementEmailResponse>> Delete([FromBody] ManagementEmailDeleteDto Model)
		{
			Response<ManagementEmailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<ManagementEmailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/managementemail")]
		public async Task<Response<ManagementEmailResponse>> Get([FromQuery] ManagementEmailSelectDto Model)
		{
			Response<ManagementEmailResponse> Response = await Service.SelectAsync(Model);
			return new Response<ManagementEmailResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
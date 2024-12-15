namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class CompanySettingsController : ControllerBase
	{
		readonly ICompanySettingsService Service;
		public CompanySettingsController(ICompanySettingsService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/companysettings")]
		public async Task<Response<CompanySettingsResponse>> Create([FromBody] CompanySettingsRegisterDto Model)
		{
			Response<CompanySettingsResponse> Response = await Service.InsertAsync(Model);
			return new Response<CompanySettingsResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/companysettings")]
		public async Task<Response<CompanySettingsResponse>> Update([FromBody] CompanySettingsUpdateDto Model)
		{
			Response<CompanySettingsResponse> Response = await Service.UpdateAsync(Model);
			return new Response<CompanySettingsResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/companysettings")]
		public async Task<Response<CompanySettingsResponse>> Delete([FromBody] CompanySettingsDeleteDto Model)
		{
			Response<CompanySettingsResponse> Response = await Service.DeleteAsync(Model);
			return new Response<CompanySettingsResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/companysettings")]
		public async Task<Response<CompanySettingsResponse>> Get([FromQuery] CompanySettingsSelectDto Model)
		{
			Response<CompanySettingsResponse> Response = await Service.SelectAsync(Model);
			return new Response<CompanySettingsResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/companysettingssingle")]
		public async Task<Response<CompanySettingsResponse>> GetSingle([FromQuery] CompanySettingsSelectDto Model)
		{
			Response<CompanySettingsResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<CompanySettingsResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
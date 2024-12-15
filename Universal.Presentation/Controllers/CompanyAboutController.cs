namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class CompanyAboutController : ControllerBase
	{
		readonly ICompanyAboutService Service;
		public CompanyAboutController(ICompanyAboutService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/companyabout")]
		public async Task<Response<CompanyAboutResponse>> Create([FromBody] CompanyAboutRegisterDto Model)
		{
			Response<CompanyAboutResponse> Response = await Service.InsertAsync(Model);
			return new Response<CompanyAboutResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/companyabout")]
		public async Task<Response<CompanyAboutResponse>> Update([FromBody] CompanyAboutUpdateDto Model)
		{
			Response<CompanyAboutResponse> Response = await Service.UpdateAsync(Model);
			return new Response<CompanyAboutResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/companyabout")]
		public async Task<Response<CompanyAboutResponse>> Delete([FromBody] CompanyAboutDeleteDto Model)
		{
			Response<CompanyAboutResponse> Response = await Service.DeleteAsync(Model);
			return new Response<CompanyAboutResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/companyabout")]
		public async Task<Response<CompanyAboutResponse>> Get([FromQuery] CompanyAboutSelectDto Model)
		{
			Response<CompanyAboutResponse> Response = await Service.SelectAsync(Model);
			return new Response<CompanyAboutResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/companyaboutsingle")]
		public async Task<Response<CompanyAboutResponse>> GetSingle([FromQuery] CompanyAboutSelectDto Model)
		{
			Response<CompanyAboutResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<CompanyAboutResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
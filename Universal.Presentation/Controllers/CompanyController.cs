namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class CompanyController : ControllerBase
	{
		readonly ICompanyService Service;
		public CompanyController(ICompanyService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/company")]
		public async Task<Response<CompanyResponse>> Create([FromBody] CompanyRegisterDto Model)
		{
			Response<CompanyResponse> Response = await Service.InsertAsync(Model);
			return new Response<CompanyResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/company")]
		public async Task<Response<CompanyResponse>> Update([FromBody] CompanyUpdateDto Model)
		{
			Response<CompanyResponse> Response = await Service.UpdateAsync(Model);
			return new Response<CompanyResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/company")]
		public async Task<Response<CompanyResponse>> Delete([FromBody] CompanyDeleteDto Model)
		{
			Response<CompanyResponse> Response = await Service.DeleteAsync(Model);
			return new Response<CompanyResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/company")]
		public async Task<Response<CompanyResponse>> Get([FromQuery] CompanySelectDto Model)
		{
			Response<CompanyResponse> Response = await Service.SelectAsync(Model);
			return new Response<CompanyResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/companysingle")]
		public async Task<Response<CompanyResponse>> GetSingle([FromQuery] CompanySelectDto Model)
		{
			Response<CompanyResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<CompanyResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class CompanyDetailController : ControllerBase
	{
		readonly ICompanyDetailService Service;
		public CompanyDetailController(ICompanyDetailService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/companydetail")]
		public async Task<Response<CompanyDetailResponse>> Create([FromBody] CompanyDetailRegisterDto Model)
		{
			Response<CompanyDetailResponse> Response = await Service.InsertAsync(Model);
			return new Response<CompanyDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/companydetail")]
		public async Task<Response<CompanyDetailResponse>> Update([FromBody] CompanyDetailUpdateDto Model)
		{
			Response<CompanyDetailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<CompanyDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/companydetail")]
		public async Task<Response<CompanyDetailResponse>> Delete([FromBody] CompanyDetailDeleteDto Model)
		{
			Response<CompanyDetailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<CompanyDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/companydetail")]
		public async Task<Response<CompanyDetailResponse>> Get([FromQuery] CompanyDetailSelectDto Model)
		{
			Response<CompanyDetailResponse> Response = await Service.SelectAsync(Model);
			return new Response<CompanyDetailResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/companydetailsingle")]
		public async Task<Response<CompanyDetailResponse>> GetSingle([FromQuery] CompanyDetailSelectDto Model)
		{
			Response<CompanyDetailResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<CompanyDetailResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
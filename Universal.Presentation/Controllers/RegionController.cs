namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class RegionController : ControllerBase
	{
		readonly IRegionService Service;
		public RegionController(IRegionService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/region")]
		public async Task<Response<RegionResponse>> Create([FromBody] RegionRegisterDto Model)
		{
			Response<RegionResponse> Response = await Service.InsertAsync(Model);
			return new Response<RegionResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/region")]
		public async Task<Response<RegionResponse>> Update([FromBody] RegionUpdateDto Model)
		{
			Response<RegionResponse> Response = await Service.UpdateAsync(Model);
			return new Response<RegionResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/region")]
		public async Task<Response<RegionResponse>> Delete([FromBody] RegionDeleteDto Model)
		{
			Response<RegionResponse> Response = await Service.DeleteAsync(Model);
			return new Response<RegionResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/region")]
		public async Task<Response<RegionResponse>> Get([FromQuery] RegionSelectDto Model)
		{
			Response<RegionResponse> Response = await Service.SelectAsync(Model);
			return new Response<RegionResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/regionsingle")]
		public async Task<Response<RegionResponse>> GetSingle([FromQuery] RegionSelectDto Model)
		{
			Response<RegionResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<RegionResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
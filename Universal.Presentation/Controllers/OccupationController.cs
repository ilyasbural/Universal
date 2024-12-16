namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class OccupationController : ControllerBase
	{
		readonly IOccupationService Service;
		public OccupationController(IOccupationService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/occupation")]
		public async Task<Response<OccupationResponse>> Create([FromBody] OccupationRegisterDto Model)
		{
			Response<OccupationResponse> Response = await Service.InsertAsync(Model);
			return new Response<OccupationResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/occupation")]
		public async Task<Response<OccupationResponse>> Update([FromBody] OccupationUpdateDto Model)
		{
			Response<OccupationResponse> Response = await Service.UpdateAsync(Model);
			return new Response<OccupationResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/occupation")]
		public async Task<Response<OccupationResponse>> Delete([FromBody] OccupationDeleteDto Model)
		{
			Response<OccupationResponse> Response = await Service.DeleteAsync(Model);
			return new Response<OccupationResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/occupation")]
		public async Task<Response<OccupationResponse>> Get([FromQuery] OccupationSelectDto Model)
		{
			Response<OccupationResponse> Response = await Service.SelectAsync(Model);
			return new Response<OccupationResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/occupationsingle")]
		public async Task<Response<OccupationResponse>> GetSingle([FromQuery] OccupationSelectDto Model)
		{
			Response<OccupationResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<OccupationResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
namespace Universal.Presentation.Controllers
{
	using Core;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
	public class AbilityController : ControllerBase
	{
		readonly IOccupationService Service;

		public AbilityController(IOccupationService service)
		{
			Service = service;
		}

		[HttpPost]
		[Authorize]
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
		[Authorize]
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
		[Authorize]
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
		[Authorize]
		[Route("api/occupation")]
		public async Task<Response<OccupationResponse>> Get([FromQuery] OccupationSelectDto Model)
		{
			Response<OccupationResponse> Response = await Service.SelectAsync(Model);
			return new Response<OccupationResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/occupationsingle")]
		public async Task<Response<OccupationResponse>> GetSingle([FromQuery] OccupationSelectDto Model)
		{
			Response<OccupationResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<OccupationResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
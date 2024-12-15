namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class SurveyController : ControllerBase
	{
		readonly ISurveyService Service;
		public SurveyController(ISurveyService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/management")]
		public async Task<Response<ManagementResponse>> Create([FromBody] ManagementRegisterDto Model)
		{
			Response<ManagementResponse> Response = await Service.InsertAsync(Model);
			return new Response<ManagementResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/management")]
		public async Task<Response<ManagementResponse>> Update([FromBody] ManagementUpdateDto Model)
		{
			Response<ManagementResponse> Response = await Service.UpdateAsync(Model);
			return new Response<ManagementResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/management")]
		public async Task<Response<ManagementResponse>> Delete([FromBody] ManagementDeleteDto Model)
		{
			Response<ManagementResponse> Response = await Service.DeleteAsync(Model);
			return new Response<ManagementResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/management")]
		public async Task<Response<ManagementResponse>> Get([FromQuery] ManagementSelectDto Model)
		{
			Response<ManagementResponse> Response = await Service.SelectAsync(Model);
			return new Response<ManagementResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/managementsingle")]
		public async Task<Response<ManagementResponse>> GetSingle([FromQuery] ManagementSelectDto Model)
		{
			Response<ManagementResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<ManagementResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
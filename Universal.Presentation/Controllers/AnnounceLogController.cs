namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class AnnounceLogController : ControllerBase
	{
		readonly IAnnounceLogService Service;

		public AnnounceLogController(IAnnounceLogService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/announcelog")]
		public async Task<Response<AnnounceLogResponse>> Create([FromBody] AnnounceLogRegisterDto Model)
		{
			Response<AnnounceLogResponse> Response = await Service.InsertAsync(Model);
			return new Response<AnnounceLogResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/announcelog")]
		public async Task<Response<AnnounceLogResponse>> Update([FromBody] AnnounceLogUpdateDto Model)
		{
			Response<AnnounceLogResponse> Response = await Service.UpdateAsync(Model);
			return new Response<AnnounceLogResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/announcelog")]
		public async Task<Response<AnnounceLogResponse>> Delete([FromBody] AnnounceLogDeleteDto Model)
		{
			Response<AnnounceLogResponse> Response = await Service.DeleteAsync(Model);
			return new Response<AnnounceLogResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/announcelog")]
		public async Task<Response<AnnounceLogResponse>> Get([FromQuery] AnnounceLogSelectDto Model)
		{
			Response<AnnounceLogResponse> Response = await Service.SelectAsync(Model);
			return new Response<AnnounceLogResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/announcelogsingle")]
		public async Task<Response<AnnounceLogResponse>> GetSingle([FromQuery] AnnounceLogSelectDto Model)
		{
			Response<AnnounceLogResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<AnnounceLogResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
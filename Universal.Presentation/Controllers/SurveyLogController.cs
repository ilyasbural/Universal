namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class SurveyLogController : ControllerBase
	{
		readonly ISurveyLogService Service;
		public SurveyLogController(ISurveyLogService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/surveylog")]
		public async Task<Response<SurveyLogResponse>> Create([FromBody] SurveyLogRegisterDto Model)
		{
			Response<SurveyLogResponse> Response = await Service.InsertAsync(Model);
			return new Response<SurveyLogResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/surveylog")]
		public async Task<Response<SurveyLogResponse>> Update([FromBody] SurveyLogUpdateDto Model)
		{
			Response<SurveyLogResponse> Response = await Service.UpdateAsync(Model);
			return new Response<SurveyLogResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/surveylog")]
		public async Task<Response<SurveyLogResponse>> Delete([FromBody] SurveyLogDeleteDto Model)
		{
			Response<SurveyLogResponse> Response = await Service.DeleteAsync(Model);
			return new Response<SurveyLogResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/surveylog")]
		public async Task<Response<SurveyLogResponse>> Get([FromQuery] SurveyLogSelectDto Model)
		{
			Response<SurveyLogResponse> Response = await Service.SelectAsync(Model);
			return new Response<SurveyLogResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/surveylogsingle")]
		public async Task<Response<SurveyLogResponse>> GetSingle([FromQuery] SurveyLogSelectDto Model)
		{
			Response<SurveyLogResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<SurveyLogResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
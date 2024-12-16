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
		[Route("api/survey")]
		public async Task<Response<SurveyResponse>> Create([FromBody] SurveyRegisterDto Model)
		{
			Response<SurveyResponse> Response = await Service.InsertAsync(Model);
			return new Response<SurveyResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/survey")]
		public async Task<Response<SurveyResponse>> Update([FromBody] SurveyUpdateDto Model)
		{
			Response<SurveyResponse> Response = await Service.UpdateAsync(Model);
			return new Response<SurveyResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/survey")]
		public async Task<Response<SurveyResponse>> Delete([FromBody] SurveyDeleteDto Model)
		{
			Response<SurveyResponse> Response = await Service.DeleteAsync(Model);
			return new Response<SurveyResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/survey")]
		public async Task<Response<SurveyResponse>> Get([FromQuery] SurveySelectDto Model)
		{
			Response<SurveyResponse> Response = await Service.SelectAsync(Model);
			return new Response<SurveyResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/surveysingle")]
		public async Task<Response<SurveyResponse>> GetSingle([FromQuery] SurveySelectDto Model)
		{
			Response<SurveyResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<SurveyResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
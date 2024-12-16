namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class SurveyDetailController : ControllerBase
	{
		readonly ISurveyDetailService Service;
		public SurveyDetailController(ISurveyDetailService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/surveydetail")]
		public async Task<Response<SurveyDetailResponse>> Create([FromBody] SurveyDetailRegisterDto Model)
		{
			Response<SurveyDetailResponse> Response = await Service.InsertAsync(Model);
			return new Response<SurveyDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/surveydetail")]
		public async Task<Response<SurveyDetailResponse>> Update([FromBody] SurveyDetailUpdateDto Model)
		{
			Response<SurveyDetailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<SurveyDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/surveydetail")]
		public async Task<Response<SurveyDetailResponse>> Delete([FromBody] SurveyDetailDeleteDto Model)
		{
			Response<SurveyDetailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<SurveyDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/surveydetail")]
		public async Task<Response<SurveyDetailResponse>> Get([FromQuery] SurveyDetailSelectDto Model)
		{
			Response<SurveyDetailResponse> Response = await Service.SelectAsync(Model);
			return new Response<SurveyDetailResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/surveydetailsingle")]
		public async Task<Response<SurveyDetailResponse>> GetSingle([FromQuery] SurveyDetailSelectDto Model)
		{
			Response<SurveyDetailResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<SurveyDetailResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
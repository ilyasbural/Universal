namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class LanguageController : ControllerBase
    {
        readonly ILanguageService Service;

        public LanguageController(ILanguageService service)
        {
            Service = service;
        }

		[HttpPost]
		[Route("api/language")]
		public async Task<Response<LanguageResponse>> Create([FromBody] LanguageRegisterDto Model)
		{
			Response<LanguageResponse> Response = await Service.InsertAsync(Model);
			return new Response<LanguageResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/language")]
		public async Task<Response<LanguageResponse>> Update([FromBody] LanguageUpdateDto Model)
		{
			Response<LanguageResponse> Response = await Service.UpdateAsync(Model);
			return new Response<LanguageResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/language")]
		public async Task<Response<LanguageResponse>> Delete([FromBody] LanguageDeleteDto Model)
		{
			Response<LanguageResponse> Response = await Service.DeleteAsync(Model);
			return new Response<LanguageResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/language")]
		public async Task<Response<LanguageResponse>> Get([FromQuery] LanguageSelectDto Model)
		{
			Response<LanguageResponse> Response = await Service.SelectAsync(Model);
			return new Response<LanguageResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/languagesingle")]
		public async Task<Response<LanguageResponse>> GetSingle([FromQuery] LanguageSelectDto Model)
		{
			Response<LanguageResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<LanguageResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
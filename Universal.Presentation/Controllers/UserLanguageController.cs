namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserLanguageController : ControllerBase
	{
		readonly IUserLanguageService Service;
		public UserLanguageController(IUserLanguageService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userlanguage")]
		public async Task<Response<UserLanguageResponse>> Create([FromBody] UserLanguageRegisterDto Model)
		{
			Response<UserLanguageResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserLanguageResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/userlanguage")]
		public async Task<Response<UserLanguageResponse>> Update([FromBody] UserLanguageUpdateDto Model)
		{
			Response<UserLanguageResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserLanguageResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userlanguage")]
		public async Task<Response<UserLanguageResponse>> Delete([FromBody] UserLanguageDeleteDto Model)
		{
			Response<UserLanguageResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserLanguageResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userlanguage")]
		public async Task<Response<UserLanguageResponse>> Get([FromQuery] UserLanguageSelectDto Model)
		{
			Response<UserLanguageResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserLanguageResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/userlanguagesingle")]
		public async Task<Response<UserLanguageResponse>> GetSingle([FromQuery] UserLanguageSelectDto Model)
		{
			Response<UserLanguageResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserLanguageResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
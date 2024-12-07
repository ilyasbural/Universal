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
	}
}
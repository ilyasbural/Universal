namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserExperienceController : ControllerBase
	{
		readonly IUserExperienceService Service;

		public UserExperienceController(IUserExperienceService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userexperience")]
		public async Task<Response<UserExperienceResponse>> Create([FromBody] UserExperienceRegisterDto Model)
		{
			Response<UserExperienceResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserExperienceResponse>
			{
				Data = Response.Data
			};
		}
	}
}
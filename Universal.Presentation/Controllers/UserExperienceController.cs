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

		[HttpPut]
		[Route("api/userexperience")]
		public async Task<Response<UserExperienceResponse>> Update([FromBody] UserExperienceUpdateDto Model)
		{
			Response<UserExperienceResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserExperienceResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userexperience")]
		public async Task<Response<UserExperienceResponse>> Delete([FromBody] UserExperienceDeleteDto Model)
		{
			Response<UserExperienceResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserExperienceResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userexperience")]
		public async Task<Response<UserExperienceResponse>> Get([FromQuery] UserExperienceSelectDto Model)
		{
			Response<UserExperienceResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserExperienceResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/userexperiencesingle")]
		public async Task<Response<UserExperienceResponse>> GetSingle([FromQuery] UserExperienceSelectDto Model)
		{
			Response<UserExperienceResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserExperienceResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserEducationController : ControllerBase
	{
		readonly IUserEducationService Service;
		public UserEducationController(IUserEducationService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/usereducation")]
		public async Task<Response<UserEducationResponse>> Create([FromBody] UserEducationRegisterDto Model)
		{
			Response<UserEducationResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserEducationResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/usereducation")]
		public async Task<Response<UserEducationResponse>> Update([FromBody] UserEducationUpdateDto Model)
		{
			Response<UserEducationResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserEducationResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/usereducation")]
		public async Task<Response<UserEducationResponse>> Delete([FromBody] UserEducationDeleteDto Model)
		{
			Response<UserEducationResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserEducationResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/usereducation")]
		public async Task<Response<UserEducationResponse>> Get([FromQuery] UserEducationSelectDto Model)
		{
			Response<UserEducationResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserEducationResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
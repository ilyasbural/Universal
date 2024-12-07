namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserProjectController : ControllerBase
	{
		readonly IUserProjectService Service;

		public UserProjectController(IUserProjectService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userproject")]
		public async Task<Response<UserProjectResponse>> Create([FromBody] UserProjectRegisterDto Model)
		{
			Response<UserProjectResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserProjectResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/userproject")]
		public async Task<Response<UserProjectResponse>> Update([FromBody] UserProjectUpdateDto Model)
		{
			Response<UserProjectResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserProjectResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userproject")]
		public async Task<Response<UserProjectResponse>> Delete([FromBody] UserProjectDeleteDto Model)
		{
			Response<UserProjectResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserProjectResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userproject")]
		public async Task<Response<UserProjectResponse>> Get([FromQuery] UserProjectSelectDto Model)
		{
			Response<UserProjectResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserProjectResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/userprojectsingle")]
		public async Task<Response<UserProjectResponse>> GetSingle([FromQuery] UserProjectSelectDto Model)
		{
			Response<UserProjectResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserProjectResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
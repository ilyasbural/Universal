namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserPublishController : ControllerBase
	{
		readonly IUserPublishService Service;

		public UserPublishController(IUserPublishService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userpublish")]
		public async Task<Response<UserPublishResponse>> Create([FromBody] UserPublishRegisterDto Model)
		{
			Response<UserPublishResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserPublishResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/userpublish")]
		public async Task<Response<UserPublishResponse>> Update([FromBody] UserPublishUpdateDto Model)
		{
			Response<UserPublishResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserPublishResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userpublish")]
		public async Task<Response<UserPublishResponse>> Delete([FromBody] UserPublishDeleteDto Model)
		{
			Response<UserPublishResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserPublishResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userpublish")]
		public async Task<Response<UserPublishResponse>> Get([FromQuery] UserPublishSelectDto Model)
		{
			Response<UserPublishResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserPublishResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/userpublishsingle")]
		public async Task<Response<UserPublishResponse>> GetSingle([FromQuery] UserPublishSelectDto Model)
		{
			Response<UserPublishResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserPublishResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
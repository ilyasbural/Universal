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
	}
}
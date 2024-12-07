namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserVideoController : ControllerBase
	{
		readonly IUserVideoService Service;

		public UserVideoController(IUserVideoService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/uservideo")]
		public async Task<Response<UserVideoResponse>> Create([FromBody] UserVideoRegisterDto Model)
		{
			Response<UserVideoResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserVideoResponse>
			{
				Data = Response.Data
			};
		}
	}
}
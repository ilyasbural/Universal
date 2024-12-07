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
	}
}
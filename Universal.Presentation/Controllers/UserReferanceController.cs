namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserReferanceController : ControllerBase
	{
		readonly IUserReferanceService Service;

		public UserReferanceController(IUserReferanceService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/userreferance")]
		public async Task<Response<UserReferanceResponse>> Create([FromBody] UserReferanceRegisterDto Model)
		{
			Response<UserReferanceResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserReferanceResponse>
			{
				Data = Response.Data
			};
		}
	}
}
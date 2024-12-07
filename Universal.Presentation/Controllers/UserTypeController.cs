namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserTypeController : ControllerBase
	{
		readonly IUserTypeService Service;

		public UserTypeController(IUserTypeService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/usertype")]
		public async Task<Response<UserTypeResponse>> Create([FromBody] UserTypeRegisterDto Model)
		{
			Response<UserTypeResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserTypeResponse>
			{
				Data = Response.Data
			};
		}
	}
}
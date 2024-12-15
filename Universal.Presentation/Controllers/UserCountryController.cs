namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class UserCountryController : ControllerBase
	{
		readonly IUserCountryService Service;
		public UserCountryController(IUserCountryService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/usercountry")]
		public async Task<Response<UserCountryResponse>> Create([FromBody] UserCountryRegisterDto Model)
		{
			Response<UserCountryResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserCountryResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/usercountry")]
		public async Task<Response<UserCountryResponse>> Update([FromBody] UserCountryUpdateDto Model)
		{
			Response<UserCountryResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserCountryResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/usercountry")]
		public async Task<Response<UserCountryResponse>> Delete([FromBody] UserCountryDeleteDto Model)
		{
			Response<UserCountryResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserCountryResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/usercountry")]
		public async Task<Response<UserCountryResponse>> Get([FromQuery] UserCountrySelectDto Model)
		{
			Response<UserCountryResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserCountryResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
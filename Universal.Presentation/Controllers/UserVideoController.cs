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

		[HttpPut]
		[Route("api/uservideo")]
		public async Task<Response<UserVideoResponse>> Update([FromBody] UserVideoUpdateDto Model)
		{
			Response<UserVideoResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserVideoResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/uservideo")]
		public async Task<Response<UserVideoResponse>> Delete([FromBody] UserVideoDeleteDto Model)
		{
			Response<UserVideoResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserVideoResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/uservideo")]
		public async Task<Response<UserVideoResponse>> Get([FromQuery] UserVideoSelectDto Model)
		{
			Response<UserVideoResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserVideoResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/uservideosingle")]
		public async Task<Response<UserVideoResponse>> GetSingle([FromQuery] UserVideoSelectDto Model)
		{
			Response<UserVideoResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserVideoResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
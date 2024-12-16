namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class NetworkCommentController : ControllerBase
	{
		readonly INetworkCommentService Service;
		public NetworkCommentController(INetworkCommentService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/networkcomment")]
		public async Task<Response<NetworkCommentResponse>> Create([FromBody] NetworkCommentRegisterDto Model)
		{
			Response<NetworkCommentResponse> Response = await Service.InsertAsync(Model);
			return new Response<NetworkCommentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/networkcomment")]
		public async Task<Response<NetworkCommentResponse>> Update([FromBody] NetworkCommentUpdateDto Model)
		{
			Response<NetworkCommentResponse> Response = await Service.UpdateAsync(Model);
			return new Response<NetworkCommentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/networkcomment")]
		public async Task<Response<NetworkCommentResponse>> Delete([FromBody] NetworkCommentDeleteDto Model)
		{
			Response<NetworkCommentResponse> Response = await Service.DeleteAsync(Model);
			return new Response<NetworkCommentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/networkcomment")]
		public async Task<Response<NetworkCommentResponse>> Get([FromQuery] NetworkCommentSelectDto Model)
		{
			Response<NetworkCommentResponse> Response = await Service.SelectAsync(Model);
			return new Response<NetworkCommentResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/networkcommentsingle")]
		public async Task<Response<NetworkCommentResponse>> GetSingle([FromQuery] NetworkCommentSelectDto Model)
		{
			Response<NetworkCommentResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<NetworkCommentResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
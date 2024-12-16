namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class NetworkActionController : ControllerBase
	{
		readonly INetworkActionService Service;
		public NetworkActionController(INetworkActionService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/networkaction")]
		public async Task<Response<NetworkActionResponse>> Create([FromBody] NetworkActionRegisterDto Model)
		{
			Response<NetworkActionResponse> Response = await Service.InsertAsync(Model);
			return new Response<NetworkActionResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/networkaction")]
		public async Task<Response<NetworkActionResponse>> Update([FromBody] NetworkActionUpdateDto Model)
		{
			Response<NetworkActionResponse> Response = await Service.UpdateAsync(Model);
			return new Response<NetworkActionResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/networkaction")]
		public async Task<Response<NetworkActionResponse>> Delete([FromBody] NetworkActionDeleteDto Model)
		{
			Response<NetworkActionResponse> Response = await Service.DeleteAsync(Model);
			return new Response<NetworkActionResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/networkaction")]
		public async Task<Response<NetworkActionResponse>> Get([FromQuery] NetworkActionSelectDto Model)
		{
			Response<NetworkActionResponse> Response = await Service.SelectAsync(Model);
			return new Response<NetworkActionResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/networkactionsingle")]
		public async Task<Response<NetworkActionResponse>> GetSingle([FromQuery] NetworkActionSelectDto Model)
		{
			Response<NetworkActionResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<NetworkActionResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
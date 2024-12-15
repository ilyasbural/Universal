namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class AnnounceController : ControllerBase
	{
		readonly IAnnounceService Service;
		public AnnounceController(IAnnounceService service)
		{
			Service = service;
		}

		[HttpGet]
		[Route("api/announce")]
		public async Task<Response<AnnounceResponse>> Get([FromQuery] AnnounceSelectDto Model)
		{
			Response<AnnounceResponse> Response = await Service.SelectAsync(Model);
			return new Response<AnnounceResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
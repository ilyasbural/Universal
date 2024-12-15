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
	}
}
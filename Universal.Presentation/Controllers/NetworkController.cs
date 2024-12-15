namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class NetworkController : ControllerBase
	{
		readonly INetworkService Service;
		public NetworkController(INetworkService service)
		{
			Service = service;
		}
	}
}
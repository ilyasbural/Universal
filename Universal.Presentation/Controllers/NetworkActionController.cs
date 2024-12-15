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
	}
}
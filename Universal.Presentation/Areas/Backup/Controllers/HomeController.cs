namespace Universal.Presentation.Areas.Backup.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	[Area("Backup")]
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
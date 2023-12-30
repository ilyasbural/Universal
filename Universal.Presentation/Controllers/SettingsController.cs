namespace Universal.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
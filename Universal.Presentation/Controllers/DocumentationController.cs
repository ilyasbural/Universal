namespace Universal.Presentation.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class DocumentationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
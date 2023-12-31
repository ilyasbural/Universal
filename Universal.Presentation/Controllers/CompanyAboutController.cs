namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class CompanyAboutController : BaseController<CompanyAboutViewModel>
    {
        public CompanyAboutController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            RestRequest = new RestRequest("api/companyabout", Method.Get);
            RestResponse = Client.Execute(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<CompanyAboutViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<CompanyAboutViewModel>(new CompanyAboutViewModel());
            return View(Model);
        }

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
    }
}
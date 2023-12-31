namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class CollegeController : BaseController<CollegeViewModel>
    {
        public CollegeController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            RestRequest = new RestRequest("api/college", Method.Get);
            RestResponse = Client.Execute(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<CollegeViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<CollegeViewModel>(new CollegeViewModel());
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
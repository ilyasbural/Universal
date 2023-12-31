namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class ManagementEmailController : BaseController<ManagementEmailViewModel>
    {
        public ManagementEmailController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            RestRequest = new RestRequest("api/managementemail", Method.Get);
            RestResponse = Client.Execute(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<ManagementEmailViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<ManagementEmailViewModel>(new ManagementEmailViewModel());
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
namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class AnnounceController : BaseController<AnnounceViewModel>
    {
        public AnnounceController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            RestRequest = new RestRequest("api/announce", Method.Get);
            RestResponse = Client.Execute(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<AnnounceViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<AnnounceViewModel>(new AnnounceViewModel());
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
namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class MessageBoxController : BaseController<MessageBoxViewModel>
    {
        public MessageBoxController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            RestRequest = new RestRequest("api/messagebox", Method.Get);
            RestResponse = Client.Execute(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<MessageBoxViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<MessageBoxViewModel>(new MessageBoxViewModel());
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
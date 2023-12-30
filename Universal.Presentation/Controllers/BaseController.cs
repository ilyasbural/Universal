namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController<T> : Controller
    {
        protected IConfiguration Configuration { get; set; }
        protected RestClient Client { get; set; } = null!;
        protected RestRequest RestRequest { get; set; } = null!;
        protected RestResponse RestResponse { get; set; } = null!;
        protected JObject Array { get; set; } = null!;
        protected List<T> ModelList { get; set; } = null!;
        protected T Model { get; set; } = default!;

        public BaseController(IConfiguration configuration)
        {
            Configuration = configuration;
            Client = new RestClient(Configuration.GetSection("RestSettings").Get<RestSettings>()!.Path);
        }
    }
}
namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class UserEducationController : BaseController<UserEducationViewModel>
    {
        public UserEducationController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/usereducation", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<UserEducationViewModel>>()!;
            return View(ModelList);
        }

        public async Task<IActionResult> Create()
        {
            var Model = Tuple.Create<UserEducationViewModel, List<UserViewModel>>
                (new UserEducationViewModel(), new List<UserViewModel>());

            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<UserViewModel>>()!);

            return View(Model);
        } 

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] UserEducationViewModel Model)
        {
            RestRequest = new RestRequest("api/usereducation", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { UserId = Model.User.Id });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "UserEducation");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<UserExperienceViewModel, List<UserViewModel>>
                (new UserExperienceViewModel(), new List<UserViewModel>());

            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<UserViewModel>>()!);

            RestRequest = new RestRequest("api/usereducationsingle", Method.Get);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddQueryParameter("Id", Id);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<UserEducation> Response = JsonConvert.DeserializeObject<Response<UserEducation>>(RestResponse.Content!)!;

            Model.Item1.User.Id = Response.Collection.First().User.Id;
            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] UserEducationViewModel Model)
        {
            RestRequest = new RestRequest("api/usereducation", Method.Put);
            RestRequest.AddJsonBody(new { UserId = Model.User.Id, Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<UserEducationViewModel>(new UserEducationViewModel());

            RestRequest = new RestRequest("api/usereducationsingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<UserEducation> Response = JsonConvert.DeserializeObject<Response<UserEducation>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] UserEducationViewModel Model)
        {
            RestRequest = new RestRequest("api/usereducation", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
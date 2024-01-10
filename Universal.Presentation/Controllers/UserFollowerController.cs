namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class UserFollowerController : BaseController<UserFollowerViewModel>
    {
        public UserFollowerController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/userfollower", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<UserFollowerViewModel>>()!;
            return View(ModelList);
        }

        public async Task<IActionResult> Create()
        {
            var Model = Tuple.Create<UserFollowerViewModel, List<UserViewModel>>
                (new UserFollowerViewModel(), new List<UserViewModel>());

            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<UserViewModel>>()!);

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] UserFollowerViewModel Model)
        {
            RestRequest = new RestRequest("api/userfollower", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { UserId = Model.User.Id });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "UserFollower");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<UserFollowerViewModel, List<UserViewModel>>
                (new UserFollowerViewModel(), new List<UserViewModel>());

            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<UserViewModel>>()!);

            RestRequest = new RestRequest("api/userfollowersingle", Method.Get);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddQueryParameter("Id", Id);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<UserFollower> Response = JsonConvert.DeserializeObject<Response<UserFollower>>(RestResponse.Content!)!;

            Model.Item1.User.Id = Response.Collection.First().User.Id;
            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] UserFollowerViewModel Model)
        {
            RestRequest = new RestRequest("api/userfollower", Method.Put);
            RestRequest.AddJsonBody(new { UserId = Model.User.Id, Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<UserFollowerViewModel>(new UserFollowerViewModel());

            RestRequest = new RestRequest("api/userfollowersingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<UserFollower> Response = JsonConvert.DeserializeObject<Response<UserFollower>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] UserFollowerViewModel Model)
        {
            RestRequest = new RestRequest("api/userfollower", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
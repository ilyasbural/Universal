﻿namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class UserVideoController : BaseController<UserVideoViewModel>
    {
        public UserVideoController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/uservideo", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<UserVideoViewModel>>()!;
            return View(ModelList);
        }

        public async Task<IActionResult> Create()
        {
            var Model = Tuple.Create<UserVideoViewModel, List<UserViewModel>>(new UserVideoViewModel(), new List<UserViewModel>());

            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<UserViewModel>>()!);

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] UserVideoViewModel Model)
        {
            RestRequest = new RestRequest("api/uservideo", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { UserId = Model.User.Id });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "UserVideo");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<UserVideoViewModel, List<UserViewModel>>(new UserVideoViewModel(), new List<UserViewModel>());

            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<UserViewModel>>()!);

            RestRequest = new RestRequest("api/uservideosingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<UserVideo> Response = JsonConvert.DeserializeObject<Response<UserVideo>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.User.Id = Response.Collection.First().User.Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] UserVideoViewModel Model)
        {
            RestRequest = new RestRequest("api/uservideo", Method.Put);
            RestRequest.AddJsonBody(new { UserId = Model.User.Id, Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<UserVideoViewModel>(new UserVideoViewModel());

            RestRequest = new RestRequest("api/uservideosingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<UserVideo> Response = JsonConvert.DeserializeObject<Response<UserVideo>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] UserVideoViewModel Model)
        {
            RestRequest = new RestRequest("api/uservideo", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
﻿namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class UserController : BaseController<UserViewModel>
    {
        public UserController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/user", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<UserViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<UserViewModel>(new UserViewModel());
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] UserViewModel Model)
        {
            RestRequest = new RestRequest("api/user", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { Email = Model.Email, Password = Model.Password });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<UserViewModel>(new UserViewModel());

            RestRequest = new RestRequest("api/usersingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<User> Response = JsonConvert.DeserializeObject<Response<User>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.Email = Response.Collection.First().Email;
            Model.Item1.Password = Response.Collection.First().Password;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] UserViewModel Model)
        {
            RestRequest = new RestRequest("api/user", Method.Put);
            RestRequest.AddJsonBody(new { Id = Model.Id, Email = Model.Email, Password = Model.Password });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<UserViewModel>(new UserViewModel());

            RestRequest = new RestRequest("api/usersingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<User> Response = JsonConvert.DeserializeObject<Response<User>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] UserViewModel Model)
        {
            RestRequest = new RestRequest("api/user", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
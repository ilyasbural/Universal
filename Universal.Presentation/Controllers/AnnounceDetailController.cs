﻿namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class AnnounceDetailController : BaseController<AnnounceDetailViewModel>
    {
        public AnnounceDetailController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/announcedetail", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<AnnounceDetailViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<AnnounceDetailViewModel>(new AnnounceDetailViewModel());
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] AnnounceDetailViewModel Model)
        {
            RestRequest = new RestRequest("api/announcedetail", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { Description = Model.Description });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "AnnounceDetail");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<AnnounceDetailViewModel>(new AnnounceDetailViewModel());

            RestRequest = new RestRequest("api/announcedetailsingle", Method.Get); 
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<AnnounceDetail> Response = JsonConvert.DeserializeObject<Response<AnnounceDetail>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.Description = Response.Collection.First().Description;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] AnnounceDetailViewModel Model)
        {
            RestRequest = new RestRequest("api/announcedetail", Method.Put);
            RestRequest.AddJsonBody(new { Id = Model.Id, Description = Model.Description });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<AnnounceDetailViewModel>(new AnnounceDetailViewModel());

            RestRequest = new RestRequest("api/announcedetailsingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<AnnounceDetail> Response = JsonConvert.DeserializeObject<Response<AnnounceDetail>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] AnnounceDetailViewModel Model)
        {
            RestRequest = new RestRequest("api/announcedetail", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
﻿namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class SurveyController : BaseController<SurveyViewModel>
    {
        public SurveyController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/survey", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<SurveyViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<SurveyViewModel>(new SurveyViewModel());
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] AbilityViewModel Model)
        {
            RestRequest = new RestRequest("api/survey", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { Name = Model.Name });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "Survey");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<SurveyViewModel>(new SurveyViewModel());

            RestRequest = new RestRequest("api/surveysingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<Survey> Response = JsonConvert.DeserializeObject<Response<Survey>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.Name = Response.Collection.First().Name;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] SurveyViewModel Model)
        {
            RestRequest = new RestRequest("api/survey", Method.Put);
            RestRequest.AddJsonBody(new { Id = Model.Id, Name = Model.Name });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<SurveyViewModel>(new SurveyViewModel());

            RestRequest = new RestRequest("api/surveysingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<Survey> Response = JsonConvert.DeserializeObject<Response<Survey>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] SurveyViewModel Model)
        {
            RestRequest = new RestRequest("api/survey", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
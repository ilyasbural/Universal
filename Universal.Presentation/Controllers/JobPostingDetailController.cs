namespace Universal.Presentation.Controllers
{
    using Core;
    using RestSharp;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using System.Collections.Generic;

    public class JobPostingDetailController : BaseController<JobPostingDetailViewModel>
    {
        public JobPostingDetailController(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<IActionResult> Index()
        {
            RestRequest = new RestRequest("api/jobpostingdetail", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<JobPostingDetailViewModel>>()!;
            return View(ModelList);
        }

        public async Task<IActionResult> Create()
        {
            var Model = Tuple.Create<JobPostingDetailViewModel, List<JobPostingViewModel>>
                (new JobPostingDetailViewModel(), new List<JobPostingViewModel>());

            RestRequest = new RestRequest("api/jobposting", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<JobPostingViewModel>>()!);

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] JobPostingDetailViewModel Model)
        {
            RestRequest = new RestRequest("api/jobpostingdetail", Method.Post);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddJsonBody(new { JobPostingId = Model.JobPosting.Id });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "JobPostingDetail");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<JobPostingDetailViewModel, List<JobPostingViewModel>>
                (new JobPostingDetailViewModel(), new List<JobPostingViewModel>());

            RestRequest = new RestRequest("api/jobposting", Method.Get);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            Model.Item2.AddRange(Array["collection"]!.ToObject<List<JobPostingViewModel>>()!);

            RestRequest = new RestRequest("api/jobpostingdetailsingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<JobPostingDetail> Response = JsonConvert.DeserializeObject<Response<JobPostingDetail>>(RestResponse.Content!)!;

            Model.Item1.JobPosting.Id = Response.Collection.First().JobPosting.Id;
            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] JobPostingDetailViewModel Model)
        {
            RestRequest = new RestRequest("api/jobpostingdetail", Method.Put);
            RestRequest.AddJsonBody(new { JobPostingId = Model.JobPosting.Id, Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<JobPostingDetailViewModel>(new JobPostingDetailViewModel());

            RestRequest = new RestRequest("api/jobpostingdetailsingle", Method.Get);
            RestRequest.AddQueryParameter("Id", Id);
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<JobPostingDetail> Response = JsonConvert.DeserializeObject<Response<JobPostingDetail>>(RestResponse.Content!)!;

            Model.Item1.Id = Response.Collection.First().Id;
            Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] JobPostingDetailViewModel Model)
        {
            RestRequest = new RestRequest("api/jobpostingdetail", Method.Delete);
            RestRequest.AddJsonBody(new { Id = Model.Id });
            RestRequest.RequestFormat = DataFormat.Json;
            RestResponse = await Client.ExecuteAsync(RestRequest);

            if (RestResponse.IsSuccessful) return RedirectToAction("Index");
            else return View(Model);
        }
    }
}
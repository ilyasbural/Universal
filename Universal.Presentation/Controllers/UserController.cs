namespace Universal.Presentation.Controllers
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
            RestRequest.AddJsonBody(new { Name = Model.Name });
            RestResponse = await Client.ExecuteAsync(RestRequest);
            return RedirectToAction("Index", "User");
        }

        public async Task<IActionResult> Update(Guid Id)
        {
            var Model = Tuple.Create<UserViewModel>(new UserViewModel());

            RestRequest = new RestRequest("api/usersingle", Method.Get);
            RestRequest.RequestFormat = DataFormat.Json;
            RestRequest.AddQueryParameter("Id", Id);
            RestResponse = await Client.ExecuteAsync(RestRequest);
            Response<User> Response = JsonConvert.DeserializeObject<Response<User>>(RestResponse.Content!)!;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] UserViewModel Model)
        {
            //BuildingTypeUpdateDto BuildingType = new BuildingTypeUpdateDto();
            //BuildingType.Id = Model.Id;
            //BuildingType.Name = Model.Name;
            //BuildingType.RegisterDate = Model.RegisterDate;
            //BuildingType.UpdateDate = Model.UpdateDate;

            //Response<BuildingType> Response = await Service.UpdateAsync(BuildingType);
            //if (Response.Success > 0) return RedirectToAction("Index");
            //else return View(Model);
            return View(Model);
        }

        public async Task<IActionResult> Delete(Guid Id)
        {
            var Model = Tuple.Create<UserViewModel>(new UserViewModel());
            //Response<BuildingType> Response = await Service.SelectSingleAsync(new BuildingTypeSelectDto { Id = Id });

            //Model.Item1.Id = Response.Collection.First().Id;
            //Model.Item1.Name = Response.Collection.First().Name;
            //Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            //Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] UserViewModel Model)
        {
            //BuildingTypeDeleteDto BuildingType = new BuildingTypeDeleteDto();
            //BuildingType.Id = Model.Id;
            //Response<BuildingType> Response = await Service.DeleteAsync(BuildingType);
            //if (Response.Success > 0) return RedirectToAction("Index");
            //else return View(Model);
            return View(Model);
        }
    }
}
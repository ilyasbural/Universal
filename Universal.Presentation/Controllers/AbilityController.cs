namespace Universal.Presentation.Controllers
{
    using RestSharp;
    using Newtonsoft.Json.Linq;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;

    public class AbilityController : BaseController<AbilityViewModel>
    {
        public AbilityController(IConfiguration configuration) : base(configuration)
        {

        }

        public IActionResult Index()
        {
            RestRequest = new RestRequest("api/ability", Method.Get);
            RestResponse = Client.Execute(RestRequest);
            Array = JObject.Parse(RestResponse.Content!);
            ModelList = Array["collection"]!.ToObject<List<AbilityViewModel>>()!;
            return View(ModelList);
        }

        public IActionResult Create()
        {
            var Model = Tuple.Create<AbilityViewModel>(new AbilityViewModel());
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind(Prefix = "Item1")] AbilityViewModel Model)
        {
            //BuildingTypeRegisterDto BuildingType = new BuildingTypeRegisterDto();
            //BuildingType.Name = Model.Name;
            //Response<BuildingType> Response = await Service.InsertAsync(BuildingType);
            //if (Response.Success > 0) return RedirectToAction("Index");
            //else return View(Model);
            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([Bind(Prefix = "Item1")] AbilityViewModel Model)
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
            var Model = Tuple.Create<AbilityViewModel>(new AbilityViewModel());
            //Response<BuildingType> Response = await Service.SelectSingleAsync(new BuildingTypeSelectDto { Id = Id });

            //Model.Item1.Id = Response.Collection.First().Id;
            //Model.Item1.Name = Response.Collection.First().Name;
            //Model.Item1.RegisterDate = Response.Collection.First().RegisterDate;
            //Model.Item1.UpdateDate = Response.Collection.First().UpdateDate;

            return View(Model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([Bind(Prefix = "Item1")] AbilityViewModel Model)
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
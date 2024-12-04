namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
    public class CompanyFollowerController : ControllerBase
    {
        readonly ICompanyFollowerService Service;

        public CompanyFollowerController(ICompanyFollowerService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollowerResponse>> Create([FromBody] CompanyFollowerRegisterDto Model)
        {
            Response<CompanyFollowerResponse> Response = await Service.InsertAsync(Model);
            return new Response<CompanyFollowerResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollowerResponse>> Update([FromBody] CompanyFollowerUpdateDto Model)
        {
            Response<CompanyFollowerResponse> Response = await Service.UpdateAsync(Model);
            return new Response<CompanyFollowerResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollowerResponse>> Delete([FromBody] CompanyFollowerDeleteDto Model)
        {
            Response<CompanyFollowerResponse> Response = await Service.DeleteAsync(Model);
            return new Response<CompanyFollowerResponse>
            {
                Data = Response.Data
            };
        }

        [HttpGet]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollowerResponse>> Get([FromQuery] CompanyFollowerSelectDto Model)
        {
            Response<CompanyFollowerResponse> Response = await Service.SelectAsync(Model);
            return new Response<CompanyFollowerResponse>
            {
                Collection = Response.Collection
            };
        }

        [HttpGet]
        [Route("api/companyfollowersingle")]
        public async Task<Response<CompanyFollowerResponse>> GetSingle([FromQuery] CompanyFollowerSelectDto Model)
        {
            Response<CompanyFollowerResponse> Response = await Service.SelectSingleAsync(Model);
            return new Response<CompanyFollowerResponse>
            {
                Collection = Response.Collection
            };
        }
    }
}
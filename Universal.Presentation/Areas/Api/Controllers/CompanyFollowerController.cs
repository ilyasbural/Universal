namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
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
        public async Task<Response<CompanyFollower>> Create([FromBody] CompanyFollowerRegisterDto Model)
        {
            Response<CompanyFollower> Response = await Service.InsertAsync(Model);
            return new Response<CompanyFollower>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollower>> Update([FromBody] CompanyFollowerUpdateDto Model)
        {
            Response<CompanyFollower> Response = await Service.UpdateAsync(Model);
            return new Response<CompanyFollower>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollower>> Delete([FromBody] CompanyFollowerDeleteDto Model)
        {
            Response<CompanyFollower> Response = await Service.DeleteAsync(Model);
            return new Response<CompanyFollower>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/companyfollower")]
        public async Task<Response<CompanyFollower>> Get()
        {
            Response<CompanyFollower> Response = await Service.SelectAsync(new CompanyFollowerSelectDto { });
            return new Response<CompanyFollower>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/companyfollowersingle")]
        public async Task<Response<CompanyFollower>> Get([FromQuery] CompanyFollowerSelectDto Model)
        {
            Response<CompanyFollower> Response = await Service.SelectSingleAsync(Model);
            return new Response<CompanyFollower>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
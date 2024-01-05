namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CompanySettingsController : ControllerBase
    {
        readonly ICompanySettingsService Service;
        public CompanySettingsController(ICompanySettingsService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/companysettings")]
        public async Task<Response<CompanySettings>> Create([FromBody] CompanySettingsRegisterDto Model)
        {
            Response<CompanySettings> Response = await Service.InsertAsync(Model);
            return new Response<CompanySettings>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/companysettings")]
        public async Task<Response<CompanySettings>> Update([FromBody] CompanySettingsUpdateDto Model)
        {
            Response<CompanySettings> Response = await Service.UpdateAsync(Model);
            return new Response<CompanySettings>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/companysettings")]
        public async Task<Response<CompanySettings>> Delete([FromBody] CompanySettingsDeleteDto Model)
        {
            Response<CompanySettings> Response = await Service.DeleteAsync(Model);
            return new Response<CompanySettings>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/companysettings")]
        public async Task<Response<CompanySettings>> Get()
        {
            Response<CompanySettings> Response = await Service.SelectAsync(new CompanySettingsSelectDto { });
            return new Response<CompanySettings>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/companysettingssingle")]
        public async Task<Response<CompanySettings>> Get([FromQuery] CompanySettingsSelectDto Model)
        {
            Response<CompanySettings> Response = await Service.SelectSingleAsync(Model);
            return new Response<CompanySettings>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
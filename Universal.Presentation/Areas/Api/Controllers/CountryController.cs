namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        readonly ICountryService Service;
        public CountryController(ICountryService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/country")]
        public async Task<Response<Country>> Create([FromBody] CountryRegisterDto Model)
        {
            Response<Country> Response = await Service.InsertAsync(Model);
            return new Response<Country>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/country")]
        public async Task<Response<Country>> Update([FromBody] CountryUpdateDto Model)
        {
            Response<Country> Response = await Service.UpdateAsync(Model);
            return new Response<Country>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/country")]
        public async Task<Response<Country>> Delete([FromBody] CountryDeleteDto Model)
        {
            Response<Country> Response = await Service.DeleteAsync(Model);
            return new Response<Country>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/country")]
        public async Task<Response<Country>> Get()
        {
            Response<Country> Response = await Service.SelectAsync(new CountrySelectDto { });
            return new Response<Country>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/countrysingle")]
        public async Task<Response<Country>> Get([FromQuery] CountrySelectDto Model)
        {
            Response<Country> Response = await Service.SelectSingleAsync(Model);
            return new Response<Country>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
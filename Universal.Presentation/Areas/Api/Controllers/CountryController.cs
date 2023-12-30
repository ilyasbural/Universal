namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("api/country")]
        public async Task<Response<Country>> Get()
        {
            Response<Country> Response = await Service.SelectAsync();
            return new Response<Country>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
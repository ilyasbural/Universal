namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        readonly IRegionService Service;
        public RegionController(IRegionService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/region")]
        public async Task<Response<Region>> Create([FromBody] RegionRegisterDto Model)
        {
            Response<Region> Response = await Service.InsertAsync(Model);
            return new Response<Region>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/region")]
        public async Task<Response<Region>> Update([FromBody] RegionUpdateDto Model)
        {
            Response<Region> Response = await Service.UpdateAsync(Model);
            return new Response<Region>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/region")]
        public async Task<Response<Region>> Delete([FromBody] RegionDeleteDto Model)
        {
            Response<Region> Response = await Service.DeleteAsync(Model);
            return new Response<Region>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/region")]
        public async Task<Response<Region>> Get()
        {
            Response<Region> Response = await Service.SelectAsync(new RegionSelectDto { });
            return new Response<Region>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/regionsingle")]
        public async Task<Response<Region>> Get([FromQuery] RegionSelectDto Model)
        {
            Response<Region> Response = await Service.SelectSingleAsync(Model);
            return new Response<Region>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
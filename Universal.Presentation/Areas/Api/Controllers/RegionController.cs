namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        //[HttpPut]
        //[Route("api/region")]
        //public async Task<RegionWebResponse> Update([FromBody] RegionUpdateDataTransfer Model)
        //{
        //    RegionServiceResponse regionServiceResponse = await Service.UpdateAsync(Model);
        //    return new RegionWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/region")]
        //public async Task<RegionWebResponse> Delete([FromBody] RegionDeleteDataTransfer Model)
        //{
        //    RegionServiceResponse regionServiceResponse = await Service.DeleteAsync(Model);
        //    return new RegionWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/region")]
        public async Task<Response<Region>> Get()
        {
            Response<Region> Response = await Service.SelectAsync();
            return new Response<Region>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/region/{id}")]
        //public async Task<RegionWebResponse> Get([FromBody] RegionAnyDataTransfer Model)
        //{
        //    RegionServiceResponse regionServiceResponse = await Service.AnySelectAsync(Model);
        //    return new RegionWebResponse
        //    {


        //    };
        //}
    }
}
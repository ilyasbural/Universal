namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class OccupationController : ControllerBase
    {
        readonly IOccupationService Service;
        public OccupationController(IOccupationService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/occupation")]
        public async Task<Response<Occupation>> Create([FromBody] OccupationRegisterDto Model)
        {
            Response<Occupation> Response = await Service.InsertAsync(Model);
            return new Response<Occupation>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        //[HttpPut]
        //[Route("api/occupation")]
        //public async Task<OccupationWebResponse> Update([FromBody] OccupationUpdateDataTransfer Model)
        //{
        //    OccupationServiceResponse announceResponse = await Service.UpdateAsync(Model);
        //    return new OccupationWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/occupation")]
        //public async Task<OccupationWebResponse> Delete([FromBody] OccupationDeleteDataTransfer Model)
        //{
        //    OccupationServiceResponse announceResponse = await Service.DeleteAsync(Model);
        //    return new OccupationWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/occupation")]
        public async Task<Response<Occupation>> Get()
        {
            Response<Occupation> Response = await Service.SelectAsync();
            return new Response<Occupation>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/occupation/{id}")]
        //public async Task<OccupationWebResponse> Get([FromBody] OccupationAnyDataTransfer Model)
        //{
        //    OccupationServiceResponse announceResponse = await Service.AnySelectAsync(Model);
        //    return new OccupationWebResponse
        //    {


        //    };
        //}
    }
}
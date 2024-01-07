namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class AnnounceDetailController : ControllerBase
    {
        readonly IAnnounceDetailService Service;
        public AnnounceDetailController(IAnnounceDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/announcedetail")]
        public async Task<Response<AnnounceDetail>> Create([FromBody] AnnounceDetailRegisterDto Model)
        {
            Response<AnnounceDetail> Response = await Service.InsertAsync(Model);
            return new Response<AnnounceDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/announcedetail")]
        public async Task<Response<AnnounceDetail>> Update([FromBody] AnnounceDetailUpdateDto Model)
        {
            Response<AnnounceDetail> Response = await Service.UpdateAsync(Model);
            return new Response<AnnounceDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/announcedetail")]
        public async Task<Response<AnnounceDetail>> Delete([FromBody] AnnounceDetailDeleteDto Model)
        {
            Response<AnnounceDetail> Response = await Service.DeleteAsync(Model);
            return new Response<AnnounceDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/announcedetail")]
        public async Task<Response<AnnounceDetail>> Get()
        {
            Response<AnnounceDetail> Response = await Service.SelectAsync(new AnnounceDetailSelectDto { });
            return new Response<AnnounceDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/announcedetailsingle")]
        public async Task<Response<AnnounceDetail>> Get([FromQuery] AnnounceDetailSelectDto Model)
        {
            Response<AnnounceDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<AnnounceDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("api/announcedetail")]
        public async Task<Response<AnnounceDetail>> Get()
        {
            Response<AnnounceDetail> Response = await Service.SelectAsync();
            return new Response<AnnounceDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
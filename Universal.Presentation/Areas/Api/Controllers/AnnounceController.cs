namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class AnnounceController : ControllerBase
    {
        readonly IAnnounceService Service;
        public AnnounceController(IAnnounceService announceService)
        {
            Service = announceService;
        }

        [HttpPost]
        [Route("api/announce")]
        public async Task<Response<Announce>> Create([FromBody] AnnounceRegisterDto Model)
        {
            Response<Announce> Response = await Service.InsertAsync(Model);
            return new Response<Announce>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/announce")]
        public async Task<Response<Announce>> Get()
        {
            Response<Announce> Response = await Service.SelectAsync();
            return new Response<Announce>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
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

        [HttpPut]
        [Route("api/announce")]
        public async Task<Response<Announce>> Update([FromBody] AnnounceUpdateDto Model)
        {
            Response<Announce> Response = await Service.UpdateAsync(Model);
            return new Response<Announce>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/announce")]
        public async Task<Response<Announce>> Delete([FromBody] AnnounceDeleteDto Model)
        {
            Response<Announce> Response = await Service.DeleteAsync(Model);
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
            Response<Announce> Response = await Service.SelectAsync(new AnnounceSelectDto { });
            return new Response<Announce>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/announcesingle")]
        public async Task<Response<Announce>> Get([FromQuery] AnnounceSelectDto Model)
        {
            Response<Announce> Response = await Service.SelectSingleAsync(Model);
            return new Response<Announce>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
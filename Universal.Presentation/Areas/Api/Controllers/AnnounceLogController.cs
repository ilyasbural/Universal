namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class AnnounceLogController : ControllerBase
    {
        readonly IAnnounceLogService Service;
        public AnnounceLogController(IAnnounceLogService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/announcelog")]
        public async Task<Response<AnnounceLog>> Create([FromBody] AnnounceLogRegisterDto Model)
        {
            Response<AnnounceLog> Response = await Service.InsertAsync(Model);
            return new Response<AnnounceLog>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/announcelog")]
        public async Task<Response<AnnounceLog>> Get()
        {
            Response<AnnounceLog> Response = await Service.SelectAsync();
            return new Response<AnnounceLog>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
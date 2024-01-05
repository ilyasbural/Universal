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

        [HttpPut]
        [Route("api/occupation")]
        public async Task<Response<Occupation>> Update([FromBody] OccupationUpdateDto Model)
        {
            Response<Occupation> Response = await Service.UpdateAsync(Model);
            return new Response<Occupation>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/occupation")]
        public async Task<Response<Occupation>> Delete([FromBody] OccupationDeleteDto Model)
        {
            Response<Occupation> Response = await Service.DeleteAsync(Model);
            return new Response<Occupation>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/occupation")]
        public async Task<Response<Occupation>> Get()
        {
            Response<Occupation> Response = await Service.SelectAsync(new OccupationSelectDto { });
            return new Response<Occupation>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/occupationsingle")]
        public async Task<Response<Occupation>> Get([FromQuery] OccupationSelectDto Model)
        {
            Response<Occupation> Response = await Service.SelectSingleAsync(Model);
            return new Response<Occupation>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        readonly IManagementService Service;
        public ManagementController(IManagementService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/management")]
        public async Task<Response<Management>> Create([FromBody] ManagementRegisterDto Model)
        {
            Response<Management> Response = await Service.InsertAsync(Model);
            return new Response<Management>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/management")]
        public async Task<Response<Management>> Update([FromBody] ManagementUpdateDto Model)
        {
            Response<Management> Response = await Service.UpdateAsync(Model);
            return new Response<Management>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/management")]
        public async Task<Response<Management>> Delete([FromBody] ManagementDeleteDto Model)
        {
            Response<Management> Response = await Service.DeleteAsync(Model);
            return new Response<Management>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/management")]
        public async Task<Response<Management>> Get()
        {
            Response<Management> Response = await Service.SelectAsync(new ManagementSelectDto { });
            return new Response<Management>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementsingle")]
        public async Task<Response<Management>> Get([FromQuery] ManagementSelectDto Model)
        {
            Response<Management> Response = await Service.SelectSingleAsync(Model);
            return new Response<Management>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
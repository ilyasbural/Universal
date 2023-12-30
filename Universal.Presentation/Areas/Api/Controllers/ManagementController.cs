namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        [HttpGet]
        [Route("api/management")]
        public async Task<Response<Management>> Get()
        {
            Response<Management> Response = await Service.SelectAsync();
            return new Response<Management>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
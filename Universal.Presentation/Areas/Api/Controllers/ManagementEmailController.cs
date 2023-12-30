namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ManagementEmailController : ControllerBase
    {
        readonly IManagementEmailService Service;
        public ManagementEmailController(IManagementEmailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/managementemail")]
        public async Task<Response<ManagementEmail>> Create([FromBody] ManagementEmailRegisterDto Model)
        {
            Response<ManagementEmail> Response = await Service.InsertAsync(Model);
            return new Response<ManagementEmail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementemail")]
        public async Task<Response<ManagementEmail>> Get()
        {
            Response<ManagementEmail> Response = await Service.SelectAsync();
            return new Response<ManagementEmail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
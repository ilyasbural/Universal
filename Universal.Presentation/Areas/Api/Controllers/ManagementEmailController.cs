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

        [HttpPut]
        [Route("api/managementemail")]
        public async Task<Response<ManagementEmail>> Update([FromBody] ManagementEmailUpdateDto Model)
        {
            Response<ManagementEmail> Response = await Service.UpdateAsync(Model);
            return new Response<ManagementEmail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/managementemail")]
        public async Task<Response<ManagementEmail>> Delete([FromBody] ManagementEmailDeleteDto Model)
        {
            Response<ManagementEmail> Response = await Service.DeleteAsync(Model);
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
            Response<ManagementEmail> Response = await Service.SelectAsync(new ManagementEmailSelectDto { });
            return new Response<ManagementEmail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementemailsingle")]
        public async Task<Response<ManagementEmail>> Get([FromQuery] ManagementEmailSelectDto Model)
        {
            Response<ManagementEmail> Response = await Service.SelectSingleAsync(Model);
            return new Response<ManagementEmail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
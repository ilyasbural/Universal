namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ManagementContactController : ControllerBase
    {
        readonly IManagementContactService Service;
        public ManagementContactController(IManagementContactService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/managementcontact")]
        public async Task<Response<ManagementContact>> Create([FromBody] ManagementContactRegisterDto Model)
        {
            Response<ManagementContact> Response = await Service.InsertAsync(Model);
            return new Response<ManagementContact>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementcontact")]
        public async Task<Response<ManagementContact>> Get()
        {
            Response<ManagementContact> Response = await Service.SelectAsync();
            return new Response<ManagementContact>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
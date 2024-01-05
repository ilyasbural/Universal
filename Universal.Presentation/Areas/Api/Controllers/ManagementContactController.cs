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

        [HttpPut]
        [Route("api/managementcontact")]
        public async Task<Response<ManagementContact>> Update([FromBody] ManagementContactUpdateDto Model)
        {
            Response<ManagementContact> Response = await Service.UpdateAsync(Model);
            return new Response<ManagementContact>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/managementcontact")]
        public async Task<Response<ManagementContact>> Delete([FromBody] ManagementContactDeleteDto Model)
        {
            Response<ManagementContact> Response = await Service.DeleteAsync(Model);
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
            Response<ManagementContact> Response = await Service.SelectAsync(new ManagementContactSelectDto { });
            return new Response<ManagementContact>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementcontactsingle")]
        public async Task<Response<ManagementContact>> Get([FromQuery] ManagementContactSelectDto Model)
        {
            Response<ManagementContact> Response = await Service.SelectSingleAsync(Model);
            return new Response<ManagementContact>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ManagementDetailController : ControllerBase
    {
        readonly IManagementDetailService Service;
        public ManagementDetailController(IManagementDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/managementdetail")]
        public async Task<Response<ManagementDetail>> Create([FromBody] ManagementDetailRegisterDto Model)
        {
            Response<ManagementDetail> Response = await Service.InsertAsync(Model);
            return new Response<ManagementDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementdetail")]
        public async Task<Response<ManagementDetail>> Get()
        {
            Response<ManagementDetail> Response = await Service.SelectAsync();
            return new Response<ManagementDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
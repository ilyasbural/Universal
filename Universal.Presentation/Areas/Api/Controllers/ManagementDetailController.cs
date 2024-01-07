namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
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

        [HttpPut]
        [Route("api/managementdetail")]
        public async Task<Response<ManagementDetail>> Update([FromBody] ManagementDetailUpdateDto Model)
        {
            Response<ManagementDetail> Response = await Service.UpdateAsync(Model);
            return new Response<ManagementDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/managementdetail")]
        public async Task<Response<ManagementDetail>> Delete([FromBody] ManagementDetailDeleteDto Model)
        {
            Response<ManagementDetail> Response = await Service.DeleteAsync(Model);
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
            Response<ManagementDetail> Response = await Service.SelectAsync(new ManagementDetailSelectDto { });
            return new Response<ManagementDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/managementdetailsingle")]
        public async Task<Response<ManagementDetail>> Get([FromQuery] ManagementDetailSelectDto Model)
        {
            Response<ManagementDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<ManagementDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
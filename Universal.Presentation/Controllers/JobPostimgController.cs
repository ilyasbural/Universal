namespace Universal.Presentation.Controllers
{
    using Core;
    using Common;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    public class JobPostingController : ControllerBase
    {
        readonly IOrganizationViewerService Service;

        public JobPostingController(IOrganizationViewerService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationviewer")]
        public async Task<Response<OrganizationViewerResponse>> Create([FromBody] OrganizationViewerRegisterDto Model)
        {
            Response<OrganizationViewerResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationViewerResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationviewer")]
        public async Task<Response<OrganizationViewerResponse>> Update([FromBody] OrganizationViewerUpdateDto Model)
        {
            Response<OrganizationViewerResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationViewerResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationviewer")]
        public async Task<Response<OrganizationViewerResponse>> Delete([FromBody] OrganizationViewerDeleteDto Model)
        {
            Response<OrganizationViewerResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationViewerResponse>
            {
                Data = Response.Data
            };
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationviewer")]
        //public async Task<Response<OrganizationViewerResponse>> Get([FromQuery] OrganizationViewerSelectDto Model)
        //{
        //    Response<OrganizationViewerResponse> Response = await Service.SelectAsync(Model);
        //    return new Response<OrganizationViewerResponse>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationviewersingle")]
        //public async Task<Response<OrganizationViewerResponse>> GetSingle([FromQuery] OrganizationViewerSelectDto Model)
        //{
        //    Response<OrganizationViewerResponse> Response = await Service.SelectSingleAsync(Model);
        //    return new Response<OrganizationViewerResponse>
        //    {
        //        Collection = Response.Collection
        //    };
        //}
    }
}
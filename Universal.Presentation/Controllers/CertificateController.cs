namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CertificateController : ControllerBase
    {
        readonly IOrganizationDetailService Service;

        public CertificateController(IOrganizationDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationdetail")]
        public async Task<Response<OrganizationDetailResponse>> Create([FromBody] OrganizationDetailRegisterDto Model)
        {
            Response<OrganizationDetailResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationDetailResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationdetail")]
        public async Task<Response<OrganizationDetailResponse>> Update([FromBody] OrganizationDetailUpdateDto Model)
        {
            Response<OrganizationDetailResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationDetailResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationdetail")]
        public async Task<Response<OrganizationDetailResponse>> Delete([FromBody] OrganizationDetailDeleteDto Model)
        {
            Response<OrganizationDetailResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationDetailResponse>
            {
                Data = Response.Data
            };
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationdetail")]
        //public async Task<Response<OrganizationDetail>> Get([FromQuery] OrganizationDetailSelectDto Model)
        //{
        //    Response<OrganizationDetail> Response = await Service.SelectAsync(Model);
        //    return new Response<OrganizationDetail>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationdetailsingle")]
        //public async Task<Response<OrganizationDetail>> GetSingle([FromQuery] OrganizationDetailSelectDto Model)
        //{
        //    Response<OrganizationDetail> Response = await Service.SelectSingleAsync(Model);
        //    return new Response<OrganizationDetail>
        //    {
        //        Collection = Response.Collection
        //    };
        //}
    }
}
namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CollegeController : ControllerBase
    {
        readonly IOrganizationExpendetureService Service;

        public CollegeController(IOrganizationExpendetureService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationexpendeture")]
        public async Task<Response<OrganizationExpendetureResponse>> Create([FromBody] OrganizationExpendetureRegisterDto Model)
        {
            Response<OrganizationExpendetureResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationExpendetureResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationexpendeture")]
        public async Task<Response<OrganizationExpendetureResponse>> Update([FromBody] OrganizationExpendetureUpdateDto Model)
        {
            Response<OrganizationExpendetureResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationExpendetureResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationexpendeture")]
        public async Task<Response<OrganizationExpendetureResponse>> Delete([FromBody] OrganizationExpendetureDeleteDto Model)
        {
            Response<OrganizationExpendetureResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationExpendetureResponse>
            {
                Data = Response.Data
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationexpendeture")]
        public async Task<Response<OrganizationExpendetureResponse>> Get([FromQuery] OrganizationExpendetureSelectDto Model)
        {
            Response<OrganizationExpendetureResponse> Response = await Service.SelectAsync(Model);
            return new Response<OrganizationExpendetureResponse>
            {
                DataSource = Response.DataSource
            };
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationexpendetureorganization")]
        //public async Task<Response<OrganizationExpendeture>> GetOrganization([FromQuery] OrganizationExpendetureSelectDto Model)
        //{
        //    Response<OrganizationExpendeture> Response = await Service.SelectOrganizationAsync(Model);
        //    return new Response<OrganizationExpendeture>
        //    {
        //        Collection = Response.Collection
        //    };
        //}

        [HttpGet]
        [Authorize]
        [Route("api/organizationexpendeturesingle")]
        public async Task<Response<OrganizationExpendetureResponse>> GetSingle([FromQuery] OrganizationExpendetureSelectDto Model)
        {
            Response<OrganizationExpendetureResponse> Response = await Service.SelectSingleAsync(Model);
            return new Response<OrganizationExpendetureResponse>
            {
                DataSource = Response.DataSource
            };
        }
    }
}
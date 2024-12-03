namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class CompanySettingsController : ControllerBase
    {
        readonly IOrganizationPaymentService Service;

        public CompanySettingsController(IOrganizationPaymentService service)
        {
            Service = service;
        }

        [HttpPost]
        [Authorize]
        [Route("api/organizationpayment")]
        public async Task<Response<OrganizationPaymentResponse>> Create([FromBody] OrganizationPaymentRegisterDto Model)
        {
            Response<OrganizationPaymentResponse> Response = await Service.InsertAsync(Model);
            return new Response<OrganizationPaymentResponse>
            {
                Data = Response.Data
            };
        }

        [HttpPut]
        [Authorize]
        [Route("api/organizationpayment")]
        public async Task<Response<OrganizationPaymentResponse>> Update([FromBody] OrganizationPaymentUpdateDto Model)
        {
            Response<OrganizationPaymentResponse> Response = await Service.UpdateAsync(Model);
            return new Response<OrganizationPaymentResponse>
            {
                Data = Response.Data
            };
        }

        [HttpDelete]
        [Authorize]
        [Route("api/organizationpayment")]
        public async Task<Response<OrganizationPaymentResponse>> Delete([FromBody] OrganizationPaymentDeleteDto Model)
        {
            Response<OrganizationPaymentResponse> Response = await Service.DeleteAsync(Model);
            return new Response<OrganizationPaymentResponse>
            {
                Data = Response.Data
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationpayment")]
        public async Task<Response<OrganizationPaymentResponse>> Get([FromQuery] OrganizationPaymentSelectDto Model)
        {
            Response<OrganizationPaymentResponse> Response = await Service.SelectAsync(Model);
            return new Response<OrganizationPaymentResponse>
            {
                DataSource = Response.DataSource
            };
        }

        [HttpGet]
        [Authorize]
        [Route("api/organizationpaymentsingle")]
        public async Task<Response<OrganizationPaymentResponse>> GetSingle([FromQuery] OrganizationPaymentSelectDto Model)
        {
            Response<OrganizationPaymentResponse> Response = await Service.SelectSingleAsync(Model);
            return new Response<OrganizationPaymentResponse>
            {
                DataSource = Response.DataSource
            };
        }

		[HttpGet]
		[Authorize]
		[Route("api/organizationpaymenforuser")]
		public async Task<Response<OrganizationPaymentResponse>> GetForUser([FromQuery] OrganizationPaymentSelectDto Model)
		{
			Response<OrganizationPaymentResponse> Response = await Service.SelectForUserAsync(Model);
			return new Response<OrganizationPaymentResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserCountryController : ControllerBase
    {
        readonly IUserPaymentService Service;

        public UserCountryController(IUserPaymentService service)
        {
            Service = service;
        }

		[HttpPost]
		[Authorize]
		[Route("api/userpayment")]
		public async Task<Response<UserPaymentResponse>> Create([FromBody] UserPaymentRegisterDto Model)
		{
			Response<UserPaymentResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserPaymentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/userpayment")]
		public async Task<Response<UserPaymentResponse>> Update([FromBody] UserPaymentUpdateDto Model)
		{
			Response<UserPaymentResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserPaymentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/userpayment")]
		public async Task<Response<UserPaymentResponse>> Delete([FromBody] UserPaymentDeleteDto Model)
		{
			Response<UserPaymentResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserPaymentResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/userpayment")]
		public async Task<Response<UserPaymentResponse>> Get([FromQuery] UserPaymentSelectDto Model)
		{
			Response<UserPaymentResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserPaymentResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
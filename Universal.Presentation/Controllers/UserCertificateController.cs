namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserCertificateController : ControllerBase
    {
        readonly IUserEmailService Service;

        public UserCertificateController(IUserEmailService service)
        {
            Service = service;
        }

		[HttpPost]
		[Authorize]
		[Route("api/useremail")]
		public async Task<Response<UserEmailResponse>> Create([FromBody] UserEmailRegisterDto Model)
		{
			Response<UserEmailResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserEmailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/useremail")]
		public async Task<Response<UserEmailResponse>> Update([FromBody] UserEmailUpdateDto Model)
		{
			Response<UserEmailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserEmailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/useremail")]
		public async Task<Response<UserEmailResponse>> Delete([FromBody] UserEmailDeleteDto Model)
		{
			Response<UserEmailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserEmailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/useremail")]
		public async Task<Response<UserEmailResponse>> Get([FromQuery] UserEmailSelectDto Model)
		{
			Response<UserEmailResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserEmailResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/useremailsingle")]
		public async Task<Response<UserEmailResponse>> GetSingle([FromQuery] UserEmailSelectDto Model)
		{
			Response<UserEmailResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserEmailResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
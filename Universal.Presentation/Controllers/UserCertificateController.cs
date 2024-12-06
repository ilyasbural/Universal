namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserCertificateController : ControllerBase
    {
        readonly IUserCertificateService Service;

        public UserCertificateController(IUserCertificateService service)
        {
            Service = service;
        }

		[HttpPost]
		[Route("api/usercertificate")]
		public async Task<Response<UserCertificateResponse>> Create([FromBody] UserCertificateRegisterDto Model)
		{
			Response<UserCertificateResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserCertificateResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/usercertificate")]
		public async Task<Response<UserCertificateResponse>> Update([FromBody] UserCertificateUpdateDto Model)
		{
			Response<UserCertificateResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserCertificateResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/usercertificate")]
		public async Task<Response<UserCertificateResponse>> Delete([FromBody] UserCertificateDeleteDto Model)
		{
			Response<UserCertificateResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserCertificateResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/usercertificate")]
		public async Task<Response<UserCertificateResponse>> Get([FromQuery] UserCertificateSelectDto Model)
		{
			Response<UserCertificateResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserCertificateResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/usercertificatesingle")]
		public async Task<Response<UserCertificateResponse>> GetSingle([FromQuery] UserCertificateSelectDto Model)
		{
			Response<UserCertificateResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserCertificateResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
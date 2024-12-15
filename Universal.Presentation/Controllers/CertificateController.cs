namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class CertificateController : ControllerBase
	{
		readonly ICertificateService Service;
		public CertificateController(ICertificateService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/certificate")]
		public async Task<Response<CertificateResponse>> Create([FromBody] CertificateRegisterDto Model)
		{
			Response<CertificateResponse> Response = await Service.InsertAsync(Model);
			return new Response<CertificateResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/certificate")]
		public async Task<Response<CertificateResponse>> Update([FromBody] CertificateUpdateDto Model)
		{
			Response<CertificateResponse> Response = await Service.UpdateAsync(Model);
			return new Response<CertificateResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/certificate")]
		public async Task<Response<CertificateResponse>> Delete([FromBody] CertificateDeleteDto Model)
		{
			Response<CertificateResponse> Response = await Service.DeleteAsync(Model);
			return new Response<CertificateResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/certificate")]
		public async Task<Response<CertificateResponse>> Get([FromQuery] CertificateSelectDto Model)
		{
			Response<CertificateResponse> Response = await Service.SelectAsync(Model);
			return new Response<CertificateResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/certificatesingle")]
		public async Task<Response<CertificateResponse>> GetSingle([FromQuery] CertificateSelectDto Model)
		{
			Response<CertificateResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<CertificateResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserAboutController : ControllerBase
    {
        readonly IUserContactService Service;

        public UserAboutController(IUserContactService service)
        {
            Service = service;
        }

		[HttpPost]
		[Authorize]
		[Route("api/usercontact")]
		public async Task<Response<UserContactResponse>> Create([FromBody] UserContactRegisterDto Model)
		{
			Response<UserContactResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserContactResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/usercontact")]
		public async Task<Response<UserContactResponse>> Update([FromBody] UserContactUpdateDto Model)
		{
			Response<UserContactResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserContactResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/usercontact")]
		public async Task<Response<UserContactResponse>> Delete([FromBody] UserContactDeleteDto Model)
		{
			Response<UserContactResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserContactResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/usercontact")]
		public async Task<Response<UserContactResponse>> Get([FromQuery] UserContactSelectDto Model)
		{
			Response<UserContactResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserContactResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/usercontactsingle")]
		public async Task<Response<UserContactResponse>> GetSingle([FromQuery] UserContactSelectDto Model)
		{
			Response<UserContactResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserContactResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
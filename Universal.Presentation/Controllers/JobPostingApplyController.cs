namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    public class JobPostingApplyController : ControllerBase
    {
        readonly IUserAddressService Service;

        public JobPostingApplyController(IUserAddressService service)
        {
            Service = service;
        }

		[HttpPost]
		[Authorize]
		[Route("api/useraddress")]
		public async Task<Response<UserAddressResponse>> Create([FromBody] UserAddressRegisterDto Model)
		{
			Response<UserAddressResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserAddressResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/useraddress")]
		public async Task<Response<UserAddressResponse>> Update([FromBody] UserAddressUpdateDto Model)
		{
			Response<UserAddressResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserAddressResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/useraddress")]
		public async Task<Response<UserAddressResponse>> Delete([FromBody] UserAddressDeleteDto Model)
		{
			Response<UserAddressResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserAddressResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/useraddress")]
		public async Task<Response<UserAddressResponse>> Get([FromQuery] UserAddressSelectDto Model)
		{
			Response<UserAddressResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserAddressResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/useraddresssingle")]
		public async Task<Response<UserAddressResponse>> GetSingle([FromQuery] UserAddressSelectDto Model)
		{
			Response<UserAddressResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserAddressResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
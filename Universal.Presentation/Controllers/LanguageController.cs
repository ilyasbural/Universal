namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    [ApiController]
    public class LanguageController : ControllerBase
    {
        readonly IUserService Service;

        public LanguageController(IUserService service)
        {
            Service = service;
        }

		[HttpPost]
		[Route("api/user")]
		public async Task<Response<UserResponse>> Create([FromBody] UserRegisterDto Model)
		{
			Response<UserResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/user")]
		public async Task<Response<UserResponse>> Update([FromBody] UserUpdateDto Model)
		{
			Response<UserResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/user")]
		public async Task<Response<UserResponse>> Delete([FromBody] UserDeleteDto Model)
		{
			Response<UserResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/changepassword")]
		public async Task<Response<UserResponse>> ChangePassword([FromBody] ChangePasswordDto Model)
		{
			Response<UserResponse> Response = await Service.ChangePasswordAsync(Model);
			return new Response<UserResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/user")]
		public async Task<Response<UserResponse>> Get([FromQuery] UserSelectDto Model)
		{
			Response<UserResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/usersingle")]
		public async Task<Response<UserResponse>> GetSingle([FromQuery] UserSelectDto Model)
		{
			Response<UserResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
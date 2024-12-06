namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService Service;

        public UserController(IUserService service)
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
		[Route("api/user")]
		public async Task<Response<UserResponse>> Delete([FromBody] UserDeleteDto Model)
		{
			Response<UserResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/user")]
		public async Task<Response<UserResponse>> Get([FromQuery] UserSelectDto Model)
		{
			Response<UserResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/usersingle")]
		public async Task<Response<UserResponse>> GetSingle([FromQuery] UserSelectDto Model)
		{
			Response<UserResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
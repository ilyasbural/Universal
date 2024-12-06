namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserDetailController : ControllerBase
    {
        readonly IUserDetailService Service;

        public UserDetailController(IUserDetailService service)
        {
            Service = service;
        }

		[HttpPost]
		[Authorize]
		[Route("api/userdetail")]
		public async Task<Response<UserDetailResponse>> Create([FromBody] UserDetailRegisterDto Model)
		{
			Response<UserDetailResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/userdetail")]
		public async Task<Response<UserDetailResponse>> Update([FromBody] UserDetailUpdateDto Model)
		{
			Response<UserDetailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Authorize]
		[Route("api/userdetailchangeprofilepicture")]
		public async Task<Response<UserDetailResponse>> UpdateProfilePicture([FromBody] UserDetailUpdateDto Model)
		{
			Response<UserDetailResponse> Response = await Service.UpdateProfilePictureAsync(Model);
			return new Response<UserDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Authorize]
		[Route("api/userdetail")]
		public async Task<Response<UserDetailResponse>> Delete([FromBody] UserDetailDeleteDto Model)
		{
			Response<UserDetailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Authorize]
		[Route("api/userdetail")]
		public async Task<Response<UserDetailResponse>> Get([FromQuery] UserDetailSelectDto Model)
		{
			Response<UserDetailResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserDetailResponse>
			{
				DataSource = Response.DataSource
			};
		}

		[HttpGet]
		[Route("api/userdetailsingle")]
		public async Task<Response<UserDetailResponse>> GetSingle([FromQuery] UserDetailSelectDto Model)
		{
			Response<UserDetailResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserDetailResponse>
			{
				DataSource = Response.DataSource
			};
		}
	}
}
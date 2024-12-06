namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserAbilityController : ControllerBase
    {
        readonly IUserAbilityService Service;

        public UserAbilityController(IUserAbilityService service)
        {
            Service = service;
        }

		[HttpPost]
		[Route("api/userability")]
		public async Task<Response<UserAbilityResponse>> Create([FromBody] UserAbilityRegisterDto Model)
		{
			Response<UserAbilityResponse> Response = await Service.InsertAsync(Model);
			return new Response<UserAbilityResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/userability")]
		public async Task<Response<UserAbilityResponse>> Update([FromBody] UserAbilityUpdateDto Model)
		{
			Response<UserAbilityResponse> Response = await Service.UpdateAsync(Model);
			return new Response<UserAbilityResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/userability")]
		public async Task<Response<UserAbilityResponse>> Delete([FromBody] UserAbilityDeleteDto Model)
		{
			Response<UserAbilityResponse> Response = await Service.DeleteAsync(Model);
			return new Response<UserAbilityResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/userability")]
		public async Task<Response<UserAbilityResponse>> Get([FromQuery] UserAbilitySelectDto Model)
		{
			Response<UserAbilityResponse> Response = await Service.SelectAsync(Model);
			return new Response<UserAbilityResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/userabilitysingle")]
		public async Task<Response<UserAbilityResponse>> GetSingle([FromQuery] UserAbilitySelectDto Model)
		{
			Response<UserAbilityResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<UserAbilityResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
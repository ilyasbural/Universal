namespace Universal.Presentation.Controllers
{
    using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class ManagementDetailController : ControllerBase
    {
        readonly IManagementDetailService Service;

        public ManagementDetailController(IManagementDetailService service)
        {
            Service = service;
        }

		[HttpPost]
		[Route("api/managementdetail")]
		public async Task<Response<ManagementDetailResponse>> Create([FromBody] ManagementDetailRegisterDto Model)
		{
			Response<ManagementDetailResponse> Response = await Service.InsertAsync(Model);
			return new Response<ManagementDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/managementdetail")]
		public async Task<Response<ManagementDetailResponse>> Update([FromBody] ManagementDetailUpdateDto Model)
		{
			Response<ManagementDetailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<ManagementDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/managementdetail")]
		public async Task<Response<ManagementDetailResponse>> Delete([FromBody] ManagementDetailDeleteDto Model)
		{
			Response<ManagementDetailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<ManagementDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/managementdetail")]
		public async Task<Response<ManagementDetailResponse>> Get([FromQuery] ManagementDetailSelectDto Model)
		{
			Response<ManagementDetailResponse> Response = await Service.SelectAsync(Model);
			return new Response<ManagementDetailResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/managementdetailsingle")]
		public async Task<Response<ManagementDetailResponse>> GetSingle([FromQuery] ManagementDetailSelectDto Model)
		{
			Response<ManagementDetailResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<ManagementDetailResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
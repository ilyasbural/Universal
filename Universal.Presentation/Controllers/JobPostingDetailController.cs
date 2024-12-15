namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class JobPostingDetailController : ControllerBase
	{
		readonly IJobPostingDetailService Service;
		public JobPostingDetailController(IJobPostingDetailService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/jobpostingdetail")]
		public async Task<Response<JobPostingDetailResponse>> Create([FromBody] JobPostingDetailRegisterDto Model)
		{
			Response<JobPostingDetailResponse> Response = await Service.InsertAsync(Model);
			return new Response<JobPostingDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/jobpostingdetail")]
		public async Task<Response<JobPostingDetailResponse>> Update([FromBody] JobPostingDetailUpdateDto Model)
		{
			Response<JobPostingDetailResponse> Response = await Service.UpdateAsync(Model);
			return new Response<JobPostingDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/jobpostingdetail")]
		public async Task<Response<JobPostingDetailResponse>> Delete([FromBody] JobPostingDetailDeleteDto Model)
		{
			Response<JobPostingDetailResponse> Response = await Service.DeleteAsync(Model);
			return new Response<JobPostingDetailResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/jobpostingdetail")]
		public async Task<Response<JobPostingDetailResponse>> Get([FromQuery] JobPostingDetailSelectDto Model)
		{
			Response<JobPostingDetailResponse> Response = await Service.SelectAsync(Model);
			return new Response<JobPostingDetailResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/jobpostingdetailsingle")]
		public async Task<Response<JobPostingDetailResponse>> GetSingle([FromQuery] JobPostingDetailSelectDto Model)
		{
			Response<JobPostingDetailResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<JobPostingDetailResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
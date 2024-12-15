namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

	[ApiController]
	public class JobPostingController : ControllerBase
	{
		readonly IJobPostingService Service;
		public JobPostingController(IJobPostingService service)
		{
			Service = service;
		}

		[HttpPost]
		[Route("api/jobposting")]
		public async Task<Response<JobPostingResponse>> Create([FromBody] JobPostingRegisterDto Model)
		{
			Response<JobPostingResponse> Response = await Service.InsertAsync(Model);
			return new Response<JobPostingResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/jobposting")]
		public async Task<Response<JobPostingResponse>> Update([FromBody] JobPostingUpdateDto Model)
		{
			Response<JobPostingResponse> Response = await Service.UpdateAsync(Model);
			return new Response<JobPostingResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/jobposting")]
		public async Task<Response<JobPostingResponse>> Delete([FromBody] JobPostingDeleteDto Model)
		{
			Response<JobPostingResponse> Response = await Service.DeleteAsync(Model);
			return new Response<JobPostingResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/jobposting")]
		public async Task<Response<JobPostingResponse>> Get([FromQuery] JobPostingSelectDto Model)
		{
			Response<JobPostingResponse> Response = await Service.SelectAsync(Model);
			return new Response<JobPostingResponse>
			{
				Collection = Response.Collection
			};
		}

		[HttpGet]
		[Route("api/jobpostingsingle")]
		public async Task<Response<JobPostingResponse>> GetSingle([FromQuery] JobPostingSelectDto Model)
		{
			Response<JobPostingResponse> Response = await Service.SelectSingleAsync(Model);
			return new Response<JobPostingResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
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
        public async Task<Response<JobPosting>> Create([FromBody] JobPostingRegisterDto Model)
        {
            Response<JobPosting> Response = await Service.InsertAsync(Model);
            return new Response<JobPosting>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/jobposting")]
        public async Task<Response<JobPosting>> Update([FromBody] JobPostingUpdateDto Model)
        {
            Response<JobPosting> Response = await Service.UpdateAsync(Model);
            return new Response<JobPosting>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/jobposting")]
        public async Task<Response<JobPosting>> Delete([FromBody] JobPostingDeleteDto Model)
        {
            Response<JobPosting> Response = await Service.DeleteAsync(Model);
            return new Response<JobPosting>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/jobposting")]
        public async Task<Response<JobPosting>> Get()
        {
            Response<JobPosting> Response = await Service.SelectAsync(new JobPostingSelectDto { });
            return new Response<JobPosting>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/jobpostingsingle")]
        public async Task<Response<JobPosting>> Get([FromQuery] JobPostingSelectDto Model)
        {
            Response<JobPosting> Response = await Service.SelectSingleAsync(Model);
            return new Response<JobPosting>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
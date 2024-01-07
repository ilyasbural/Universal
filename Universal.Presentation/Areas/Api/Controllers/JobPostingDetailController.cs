namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
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
        public async Task<Response<JobPostingDetail>> Create([FromBody] JobPostingDetailRegisterDto Model)
        {
            Response<JobPostingDetail> Response = await Service.InsertAsync(Model);
            return new Response<JobPostingDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/jobpostingdetail")]
        public async Task<Response<JobPostingDetail>> Update([FromBody] JobPostingDetailUpdateDto Model)
        {
            Response<JobPostingDetail> Response = await Service.UpdateAsync(Model);
            return new Response<JobPostingDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/jobpostingdetail")]
        public async Task<Response<JobPostingDetail>> Delete([FromBody] JobPostingDetailDeleteDto Model)
        {
            Response<JobPostingDetail> Response = await Service.DeleteAsync(Model);
            return new Response<JobPostingDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/jobpostingdetail")]
        public async Task<Response<JobPostingDetail>> Get()
        {
            Response<JobPostingDetail> Response = await Service.SelectAsync(new JobPostingDetailSelectDto { });
            return new Response<JobPostingDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/jobpostingdetailsingle")]
        public async Task<Response<JobPostingDetail>> Get([FromQuery] JobPostingDetailSelectDto Model)
        {
            Response<JobPostingDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<JobPostingDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
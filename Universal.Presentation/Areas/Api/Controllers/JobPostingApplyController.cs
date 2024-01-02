namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class JobPostingApplyController : ControllerBase
    {
        readonly IJobPostingApplyService Service;
        public JobPostingApplyController(IJobPostingApplyService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/jobpostingapply")]
        public async Task<Response<JobPostingApply>> Create([FromBody] JobPostingApplyRegisterDto Model)
        {
            Response<JobPostingApply> Response = await Service.InsertAsync(Model);
            return new Response<JobPostingApply>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/jobpostingapply")]
        public async Task<Response<JobPostingApply>> Update([FromBody] JobPostingApplyUpdateDto Model)
        {
            Response<JobPostingApply> Response = await Service.UpdateAsync(Model);
            return new Response<JobPostingApply>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/jobpostingapply")]
        public async Task<Response<JobPostingApply>> Delete([FromBody] JobPostingApplyDeleteDto Model)
        {
            Response<JobPostingApply> Response = await Service.DeleteAsync(Model);
            return new Response<JobPostingApply>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/jobpostingapply")]
        public async Task<Response<JobPostingApply>> Get()
        {
            Response<JobPostingApply> Response = await Service.SelectAsync(new JobPostingApplySelectDto { });
            return new Response<JobPostingApply>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/ability/{id}")]
        //public async Task<AbilityWebResponse> Get([FromBody] AbilityAnyDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.AnySelectAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}
    }
}
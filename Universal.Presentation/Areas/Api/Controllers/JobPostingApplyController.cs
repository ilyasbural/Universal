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

        //[HttpPut]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Update([FromBody] AbilityUpdateDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.UpdateAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Delete([FromBody] AbilityDeleteDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.DeleteAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/jobpostingapply")]
        public async Task<Response<JobPostingApply>> Get()
        {
            Response<JobPostingApply> Response = await Service.SelectAsync();
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
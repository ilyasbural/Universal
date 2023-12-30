namespace Universal.Api.Controllers
{
    using Core;
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
        public async Task<Response<JobPostingDetail>> Create([FromBody] JobPostingDetailRegisterDto Model)
        {
            Response<JobPostingDetail> Response = await Service.InsertAsync(Model);
            return new Response<JobPostingDetail>
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
        [Route("api/jobpostingdetail")]
        public async Task<Response<JobPostingDetail>> Get()
        {
            Response<JobPostingDetail> Response = await Service.SelectAsync();
            return new Response<JobPostingDetail>
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
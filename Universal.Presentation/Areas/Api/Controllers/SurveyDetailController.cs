namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class SurveyDetailController : ControllerBase
    {
        readonly ISurveyDetailService Service;
        public SurveyDetailController(ISurveyDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/surveydetail")]
        public async Task<Response<SurveyDetail>> Create([FromBody] SurveyDetailRegisterDto Model)
        {
            Response<SurveyDetail> Response = await Service.InsertAsync(Model);
            return new Response<SurveyDetail>
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
        [Route("api/surveydetail")]
        public async Task<Response<SurveyDetail>> Get()
        {
            Response<SurveyDetail> Response = await Service.SelectAsync();
            return new Response<SurveyDetail>
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
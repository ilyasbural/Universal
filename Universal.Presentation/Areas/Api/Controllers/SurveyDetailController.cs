namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
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

        [HttpPut]
        [Route("api/surveydetail")]
        public async Task<Response<SurveyDetail>> Update([FromBody] SurveyDetailUpdateDto Model)
        {
            Response<SurveyDetail> Response = await Service.UpdateAsync(Model);
            return new Response<SurveyDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/surveydetail")]
        public async Task<Response<SurveyDetail>> Delete([FromBody] SurveyDetailDeleteDto Model)
        {
            Response<SurveyDetail> Response = await Service.DeleteAsync(Model);
            return new Response<SurveyDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveydetail")]
        public async Task<Response<SurveyDetail>> Get()
        {
            Response<SurveyDetail> Response = await Service.SelectAsync(new SurveyDetailSelectDto { });
            return new Response<SurveyDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveydetailsingle")]
        public async Task<Response<SurveyDetail>> Get([FromQuery] SurveyDetailSelectDto Model)
        {
            Response<SurveyDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<SurveyDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
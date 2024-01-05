namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class SurveyHistoryController : ControllerBase
    {
        readonly ISurveyHistoryService Service;
        public SurveyHistoryController(ISurveyHistoryService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/surveyhistory")]
        public async Task<Response<SurveyHistory>> Create([FromBody] SurveyHistoryRegisterDto Model)
        {
            Response<SurveyHistory> Response = await Service.InsertAsync(Model);
            return new Response<SurveyHistory>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/surveyhistory")]
        public async Task<Response<SurveyHistory>> Update([FromBody] SurveyHistoryUpdateDto Model)
        {
            Response<SurveyHistory> Response = await Service.UpdateAsync(Model);
            return new Response<SurveyHistory>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/surveyhistory")]
        public async Task<Response<SurveyHistory>> Delete([FromBody] SurveyHistoryDeleteDto Model)
        {
            Response<SurveyHistory> Response = await Service.DeleteAsync(Model);
            return new Response<SurveyHistory>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveyhistory")]
        public async Task<Response<SurveyHistory>> Get()
        {
            Response<SurveyHistory> Response = await Service.SelectAsync(new SurveyHistorySelectDto { });
            return new Response<SurveyHistory>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveyhistorysingle")]
        public async Task<Response<SurveyHistory>> Get([FromQuery] SurveyHistorySelectDto Model)
        {
            Response<SurveyHistory> Response = await Service.SelectSingleAsync(Model);
            return new Response<SurveyHistory>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
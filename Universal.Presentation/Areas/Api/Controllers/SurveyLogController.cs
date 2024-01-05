namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class SurveyLogController : ControllerBase
    {
        readonly ISurveyLogService Service;
        public SurveyLogController(ISurveyLogService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/surveylog")]
        public async Task<Response<SurveyLog>> Create([FromBody] SurveyLogRegisterDto Model)
        {
            Response<SurveyLog> Response = await Service.InsertAsync(Model);
            return new Response<SurveyLog>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/surveylog")]
        public async Task<Response<SurveyLog>> Update([FromBody] SurveyLogUpdateDto Model)
        {
            Response<SurveyLog> Response = await Service.UpdateAsync(Model);
            return new Response<SurveyLog>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/surveylog")]
        public async Task<Response<SurveyLog>> Delete([FromBody] SurveyLogDeleteDto Model)
        {
            Response<SurveyLog> Response = await Service.DeleteAsync(Model);
            return new Response<SurveyLog>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveylog")]
        public async Task<Response<SurveyLog>> Get()
        {
            Response<SurveyLog> Response = await Service.SelectAsync(new SurveyLogSelectDto { });
            return new Response<SurveyLog>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveylogsingle")]
        public async Task<Response<SurveyLog>> Get([FromQuery] SurveyLogSelectDto Model)
        {
            Response<SurveyLog> Response = await Service.SelectSingleAsync(Model);
            return new Response<SurveyLog>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
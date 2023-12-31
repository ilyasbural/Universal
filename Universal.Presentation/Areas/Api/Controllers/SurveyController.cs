﻿namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        readonly ISurveyService Service;
        public SurveyController(ISurveyService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/survey")]
        public async Task<Response<Survey>> Create([FromBody] SurveyRegisterDto Model)
        {
            Response<Survey> Response = await Service.InsertAsync(Model);
            return new Response<Survey>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/survey")]
        public async Task<Response<Survey>> Update([FromBody] SurveyUpdateDto Model)
        {
            Response<Survey> Response = await Service.UpdateAsync(Model);
            return new Response<Survey>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/survey")]
        public async Task<Response<Survey>> Delete([FromBody] SurveyDeleteDto Model)
        {
            Response<Survey> Response = await Service.DeleteAsync(Model);
            return new Response<Survey>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/survey")]
        public async Task<Response<Survey>> Get()
        {
            Response<Survey> Response = await Service.SelectAsync(new SurveySelectDto { });
            return new Response<Survey>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/surveysingle")]
        public async Task<Response<Survey>> Get([FromQuery] SurveySelectDto Model)
        {
            Response<Survey> Response = await Service.SelectSingleAsync(Model);
            return new Response<Survey>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
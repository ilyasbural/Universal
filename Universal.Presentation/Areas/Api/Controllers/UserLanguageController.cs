﻿namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class UserLanguageController : ControllerBase
    {
        readonly IUserLanguageService Service;
        public UserLanguageController(IUserLanguageService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userlanguage")]
        public async Task<Response<UserLanguage>> Create([FromBody] UserLanguageRegisterDto Model)
        {
            Response<UserLanguage> Response = await Service.InsertAsync(Model);
            return new Response<UserLanguage>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userlanguage")]
        public async Task<Response<UserLanguage>> Update([FromBody] UserLanguageUpdateDto Model)
        {
            Response<UserLanguage> Response = await Service.UpdateAsync(Model);
            return new Response<UserLanguage>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userlanguage")]
        public async Task<Response<UserLanguage>> Delete([FromBody] UserLanguageDeleteDto Model)
        {
            Response<UserLanguage> Response = await Service.DeleteAsync(Model);
            return new Response<UserLanguage>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userlanguage")]
        public async Task<Response<UserLanguage>> Get()
        {
            Response<UserLanguage> Response = await Service.SelectAsync(new UserLanguageSelectDto { });
            return new Response<UserLanguage>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userlanguagesingle")]
        public async Task<Response<UserLanguage>> Get([FromQuery] UserLanguageSelectDto Model)
        {
            Response<UserLanguage> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserLanguage>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
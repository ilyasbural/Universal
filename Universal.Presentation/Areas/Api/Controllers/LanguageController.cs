namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class LanguageController : ControllerBase
    {
        readonly ILanguageService Service;
        public LanguageController(ILanguageService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/language")]
        public async Task<Response<Language>> Create([FromBody] LanguageRegisterDto Model)
        {
            Response<Language> Response = await Service.InsertAsync(Model);
            return new Response<Language>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/language")]
        public async Task<Response<Language>> Update([FromBody] LanguageUpdateDto Model)
        {
            Response<Language> Response = await Service.UpdateAsync(Model);
            return new Response<Language>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/language")]
        public async Task<Response<Language>> Delete([FromBody] LanguageDeleteDto Model)
        {
            Response<Language> Response = await Service.DeleteAsync(Model);
            return new Response<Language>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/language")]
        public async Task<Response<Language>> Get()
        {
            Response<Language> Response = await Service.SelectAsync(new LanguageSelectDto { });
            return new Response<Language>
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
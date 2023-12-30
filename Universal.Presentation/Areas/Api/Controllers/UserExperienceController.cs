namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserExperienceController : ControllerBase
    {
        readonly IUserExperienceService Service;
        public UserExperienceController(IUserExperienceService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userexperience")]
        public async Task<Response<UserExperience>> Create([FromBody] UserExperienceRegisterDto Model)
        {
            Response<UserExperience> Response = await Service.InsertAsync(Model);
            return new Response<UserExperience>
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
        [Route("api/userexperience")]
        public async Task<Response<UserExperience>> Get()
        {
            Response<UserExperience> Response = await Service.SelectAsync();
            return new Response<UserExperience>
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
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
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

        [HttpPut]
        [Route("api/userexperience")]
        public async Task<Response<UserExperience>> Update([FromBody] UserExperienceUpdateDto Model)
        {
            Response<UserExperience> Response = await Service.UpdateAsync(Model);
            return new Response<UserExperience>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userexperience")]
        public async Task<Response<UserExperience>> Delete([FromBody] UserExperienceDeleteDto Model)
        {
            Response<UserExperience> Response = await Service.DeleteAsync(Model);
            return new Response<UserExperience>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userexperience")]
        public async Task<Response<UserExperience>> Get()
        {
            Response<UserExperience> Response = await Service.SelectAsync(new UserExperienceSelectDto { });
            return new Response<UserExperience>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userexperiencesingle")]
        public async Task<Response<UserExperience>> Get([FromQuery] UserExperienceSelectDto Model)
        {
            Response<UserExperience> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserExperience>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
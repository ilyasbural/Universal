namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserProjectController : ControllerBase
    {
        readonly IUserProjectService Service;
        public UserProjectController(IUserProjectService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userproject")]
        public async Task<Response<UserProject>> Create([FromBody] UserProjectRegisterDto Model)
        {
            Response<UserProject> Response = await Service.InsertAsync(Model);
            return new Response<UserProject>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userproject")]
        public async Task<Response<UserProject>> Update([FromBody] UserProjectUpdateDto Model)
        {
            Response<UserProject> Response = await Service.UpdateAsync(Model);
            return new Response<UserProject>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userproject")]
        public async Task<Response<UserProject>> Delete([FromBody] UserProjectDeleteDto Model)
        {
            Response<UserProject> Response = await Service.DeleteAsync(Model);
            return new Response<UserProject>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userproject")]
        public async Task<Response<UserProject>> Get()
        {
            Response<UserProject> Response = await Service.SelectAsync(new UserProjectSelectDto { });
            return new Response<UserProject>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userprojectsingle")]
        public async Task<Response<UserProject>> Get([FromQuery] UserProjectSelectDto Model)
        {
            Response<UserProject> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserProject>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
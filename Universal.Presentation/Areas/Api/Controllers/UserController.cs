namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IUserService Service;
        public UserController(IUserService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/user")]
        public async Task<Response<User>> Create([FromBody] UserRegisterDto Model)
        {
            Response<User> Response = await Service.InsertAsync(Model);
            return new Response<User>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/user")]
        public async Task<Response<User>> Update([FromBody] UserUpdateDto Model)
        {
            Response<User> Response = await Service.UpdateAsync(Model);
            return new Response<User>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/user")]
        public async Task<Response<User>> Delete([FromBody] UserDeleteDto Model)
        {
            Response<User> Response = await Service.DeleteAsync(Model);
            return new Response<User>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/user")]
        public async Task<Response<User>> Get()
        {
            Response<User> Response = await Service.SelectAsync(new UserSelectDto { });
            return new Response<User>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usersingle")]
        public async Task<Response<User>> Get([FromQuery] UserSelectDto Model)
        {
            Response<User> Response = await Service.SelectSingleAsync(Model);
            return new Response<User>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        //[HttpPut]
        //[Route("api/user")]
        //public async Task<UserWebResponse> Update([FromBody] UserUpdateDataTransfer Model)
        //{
        //    UserServiceResponse userServiceResponse = await Service.UpdateAsync(Model);
        //    return new UserWebResponse
        //    {
        //        Single = userServiceResponse.Single,
        //        Success = userServiceResponse.Success
        //    };
        //}

        //[HttpDelete]
        //[Route("api/user")]
        //public async Task<UserWebResponse> Delete([FromBody] UserDeleteDataTransfer Model)
        //{
        //    UserServiceResponse userServiceResponse = await Service.DeleteAsync(Model);
        //    return new UserWebResponse
        //    {
        //        Single = userServiceResponse.Single,
        //        Success = userServiceResponse.Success
        //    };
        //}

        [HttpGet]
        [Route("api/user")]
        public async Task<Response<User>> Get()
        {
            Response<User> Response = await Service.SelectAsync();
            return new Response<User>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/user/{id}")]
        //public async Task<UserWebResponse> Get([FromBody] UserAnyDataTransfer Model)
        //{
        //    UserServiceResponse userServiceResponse = await Service.AnySelectAsync(Model);
        //    return new UserWebResponse
        //    {
        //        Success = userServiceResponse.Success
        //    };
        //}
    }
}
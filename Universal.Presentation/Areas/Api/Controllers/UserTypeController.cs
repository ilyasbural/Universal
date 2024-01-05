namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserTypeController : ControllerBase
    {
        readonly IUserTypeService Service;
        public UserTypeController(IUserTypeService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/usertype")]
        public async Task<Response<UserType>> Create([FromBody] UserTypeRegisterDto Model)
        {
            Response<UserType> Response = await Service.InsertAsync(Model);
            return new Response<UserType>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/usertype")]
        public async Task<Response<UserType>> Update([FromBody] UserTypeUpdateDto Model)
        {
            Response<UserType> Response = await Service.UpdateAsync(Model);
            return new Response<UserType>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/usertype")]
        public async Task<Response<UserType>> Delete([FromBody] UserTypeDeleteDto Model)
        {
            Response<UserType> Response = await Service.DeleteAsync(Model);
            return new Response<UserType>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usertype")]
        public async Task<Response<UserType>> Get()
        {
            Response<UserType> Response = await Service.SelectAsync(new UserTypeSelectDto { });
            return new Response<UserType>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usertypesingle")]
        public async Task<Response<UserType>> Get([FromQuery] UserTypeSelectDto Model)
        {
            Response<UserType> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserType>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
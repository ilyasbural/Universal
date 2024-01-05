namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserDetailController : ControllerBase
    {
        readonly IUserDetailService Service;
        public UserDetailController(IUserDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userdetail")]
        public async Task<Response<UserDetail>> Create([FromBody] UserDetailRegisterDto Model)
        {
            Response<UserDetail> Response = await Service.InsertAsync(Model);
            return new Response<UserDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userdetail")]
        public async Task<Response<UserDetail>> Update([FromBody] UserDetailUpdateDto Model)
        {
            Response<UserDetail> Response = await Service.UpdateAsync(Model);
            return new Response<UserDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userdetail")]
        public async Task<Response<UserDetail>> Delete([FromBody] UserDetailDeleteDto Model)
        {
            Response<UserDetail> Response = await Service.DeleteAsync(Model);
            return new Response<UserDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userdetail")]
        public async Task<Response<UserDetail>> Get()
        {
            Response<UserDetail> Response = await Service.SelectAsync(new UserDetailSelectDto { });
            return new Response<UserDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userdetailsingle")]
        public async Task<Response<UserDetail>> Get([FromQuery] UserDetailSelectDto Model)
        {
            Response<UserDetail> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
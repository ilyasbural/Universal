namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserVideoController : ControllerBase
    {
        readonly IUserVideoService Service;
        public UserVideoController(IUserVideoService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/uservideo")]
        public async Task<Response<UserVideo>> Create([FromBody] UserVideoRegisterDto Model)
        {
            Response<UserVideo> Response = await Service.InsertAsync(Model);
            return new Response<UserVideo>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/uservideo")]
        public async Task<Response<UserVideo>> Update([FromBody] UserVideoUpdateDto Model)
        {
            Response<UserVideo> Response = await Service.UpdateAsync(Model);
            return new Response<UserVideo>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/uservideo")]
        public async Task<Response<UserVideo>> Delete([FromBody] UserVideoDeleteDto Model)
        {
            Response<UserVideo> Response = await Service.DeleteAsync(Model);
            return new Response<UserVideo>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/uservideo")]
        public async Task<Response<UserVideo>> Get()
        {
            Response<UserVideo> Response = await Service.SelectAsync(new UserVideoSelectDto { });
            return new Response<UserVideo>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/uservideosingle")]
        public async Task<Response<UserVideo>> Get([FromQuery] UserVideoSelectDto Model)
        {
            Response<UserVideo> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserVideo>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
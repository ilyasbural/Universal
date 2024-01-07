namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class UserPublishController : ControllerBase
    {
        readonly IUserPublishService Service;
        public UserPublishController(IUserPublishService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userpublish")]
        public async Task<Response<UserPublish>> Create([FromBody] UserPublishRegisterDto Model)
        {
            Response<UserPublish> Response = await Service.InsertAsync(Model);
            return new Response<UserPublish>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userpublish")]
        public async Task<Response<UserPublish>> Update([FromBody] UserPublishUpdateDto Model)
        {
            Response<UserPublish> Response = await Service.UpdateAsync(Model);
            return new Response<UserPublish>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userpublish")]
        public async Task<Response<UserPublish>> Delete([FromBody] UserPublishDeleteDto Model)
        {
            Response<UserPublish> Response = await Service.DeleteAsync(Model);
            return new Response<UserPublish>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userpublish")]
        public async Task<Response<UserPublish>> Get()
        {
            Response<UserPublish> Response = await Service.SelectAsync(new UserPublishSelectDto { });
            return new Response<UserPublish>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userpublishsingle")]
        public async Task<Response<UserPublish>> Get([FromQuery] UserPublishSelectDto Model)
        {
            Response<UserPublish> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserPublish>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
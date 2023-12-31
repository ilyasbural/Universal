﻿namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class UserFollowerController : ControllerBase
    {
        readonly IUserFollowerService Service;
        public UserFollowerController(IUserFollowerService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userfollower")]
        public async Task<Response<UserFollower>> Create([FromBody] UserFollowerRegisterDto Model)
        {
            Response<UserFollower> Response = await Service.InsertAsync(Model);
            return new Response<UserFollower>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/userfollower")]
        public async Task<Response<UserFollower>> Update([FromBody] UserFollowerUpdateDto Model)
        {
            Response<UserFollower> Response = await Service.UpdateAsync(Model);
            return new Response<UserFollower>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/userfollower")]
        public async Task<Response<UserFollower>> Delete([FromBody] UserFollowerDeleteDto Model)
        {
            Response<UserFollower> Response = await Service.DeleteAsync(Model);
            return new Response<UserFollower>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userfollower")]
        public async Task<Response<UserFollower>> Get()
        {
            Response<UserFollower> Response = await Service.SelectAsync(new UserFollowerSelectDto { });
            return new Response<UserFollower>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/userfollowersingle")]
        public async Task<Response<UserFollower>> Get([FromQuery] UserFollowerSelectDto Model)
        {
            Response<UserFollower> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserFollower>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
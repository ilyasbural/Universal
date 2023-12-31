﻿namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class MessageBoxController : ControllerBase
    {
        readonly IMessageBoxService Service;
        public MessageBoxController(IMessageBoxService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/messagebox")]
        public async Task<Response<MessageBox>> Create([FromBody] MessageBoxRegisterDto Model)
        {
            Response<MessageBox> Response = await Service.InsertAsync(Model);
            return new Response<MessageBox>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/messagebox")]
        public async Task<Response<MessageBox>> Update([FromBody] MessageBoxUpdateDto Model)
        {
            Response<MessageBox> Response = await Service.UpdateAsync(Model);
            return new Response<MessageBox>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/messagebox")]
        public async Task<Response<MessageBox>> Delete([FromBody] MessageBoxDeleteDto Model)
        {
            Response<MessageBox> Response = await Service.DeleteAsync(Model);
            return new Response<MessageBox>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/messagebox")]
        public async Task<Response<MessageBox>> Get()
        {
            Response<MessageBox> Response = await Service.SelectAsync(new MessageBoxSelectDto { });
            return new Response<MessageBox>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/messageboxsingle")]
        public async Task<Response<MessageBox>> Get([FromQuery] MessageBoxSelectDto Model)
        {
            Response<MessageBox> Response = await Service.SelectSingleAsync(Model);
            return new Response<MessageBox>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class EmojiController : ControllerBase
    {
        readonly IEmojiService Service;
        public EmojiController(IEmojiService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/emoji")]
        public async Task<Response<Emoji>> Create([FromBody] EmojiRegisterDto Model)
        {
            Response<Emoji> Response = await Service.InsertAsync(Model);
            return new Response<Emoji>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/emoji")]
        public async Task<Response<Emoji>> Update([FromBody] EmojiUpdateDto Model)
        {
            Response<Emoji> Response = await Service.UpdateAsync(Model);
            return new Response<Emoji>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/emoji")]
        public async Task<Response<Emoji>> Delete([FromBody] EmojiDeleteDto Model)
        {
            Response<Emoji> Response = await Service.DeleteAsync(Model);
            return new Response<Emoji>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/emoji")]
        public async Task<Response<Emoji>> Get()
        {
            Response<Emoji> Response = await Service.SelectAsync(new EmojiSelectDto { });
            return new Response<Emoji>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/emojisingle")]
        public async Task<Response<Emoji>> Get([FromQuery] EmojiSelectDto Model)
        {
            Response<Emoji> Response = await Service.SelectSingleAsync(Model);
            return new Response<Emoji>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
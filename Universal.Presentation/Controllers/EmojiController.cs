namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

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
		public async Task<Response<EmojiResponse>> Create([FromBody] EmojiRegisterDto Model)
		{
			Response<EmojiResponse> Response = await Service.InsertAsync(Model);
			return new Response<EmojiResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/emoji")]
		public async Task<Response<EmojiResponse>> Update([FromBody] EmojiUpdateDto Model)
		{
			Response<EmojiResponse> Response = await Service.UpdateAsync(Model);
			return new Response<EmojiResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/emoji")]
		public async Task<Response<EmojiResponse>> Delete([FromBody] EmojiDeleteDto Model)
		{
			Response<EmojiResponse> Response = await Service.DeleteAsync(Model);
			return new Response<EmojiResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/emoji")]
		public async Task<Response<EmojiResponse>> Get([FromQuery] EmojiSelectDto Model)
		{
			Response<EmojiResponse> Response = await Service.SelectAsync(Model);
			return new Response<EmojiResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
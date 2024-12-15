namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;

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
		public async Task<Response<MessageBoxResponse>> Create([FromBody] MessageBoxRegisterDto Model)
		{
			Response<MessageBoxResponse> Response = await Service.InsertAsync(Model);
			return new Response<MessageBoxResponse>
			{
				Data = Response.Data
			};
		}

		[HttpPut]
		[Route("api/messagebox")]
		public async Task<Response<MessageBoxResponse>> Update([FromBody] MessageBoxUpdateDto Model)
		{
			Response<MessageBoxResponse> Response = await Service.UpdateAsync(Model);
			return new Response<MessageBoxResponse>
			{
				Data = Response.Data
			};
		}

		[HttpDelete]
		[Route("api/messagebox")]
		public async Task<Response<MessageBoxResponse>> Delete([FromBody] MessageBoxDeleteDto Model)
		{
			Response<MessageBoxResponse> Response = await Service.DeleteAsync(Model);
			return new Response<MessageBoxResponse>
			{
				Data = Response.Data
			};
		}

		[HttpGet]
		[Route("api/messagebox")]
		public async Task<Response<MessageBoxResponse>> Get([FromQuery] MessageBoxSelectDto Model)
		{
			Response<MessageBoxResponse> Response = await Service.SelectAsync(Model);
			return new Response<MessageBoxResponse>
			{
				Collection = Response.Collection
			};
		}
	}
}
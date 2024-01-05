namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class NetworkCommentController : ControllerBase
    {
        readonly INetworkCommentService Service;
        public NetworkCommentController(INetworkCommentService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/networkcomment")]
        public async Task<Response<NetworkComment>> Create([FromBody] NetworkCommentRegisterDto Model)
        {
            Response<NetworkComment> Response = await Service.InsertAsync(Model);
            return new Response<NetworkComment>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/networkcomment")]
        public async Task<Response<NetworkComment>> Update([FromBody] NetworkCommentUpdateDto Model)
        {
            Response<NetworkComment> Response = await Service.UpdateAsync(Model);
            return new Response<NetworkComment>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/networkcomment")]
        public async Task<Response<NetworkComment>> Delete([FromBody] NetworkCommentDeleteDto Model)
        {
            Response<NetworkComment> Response = await Service.DeleteAsync(Model);
            return new Response<NetworkComment>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networkcomment")]
        public async Task<Response<NetworkComment>> Get()
        {
            Response<NetworkComment> Response = await Service.SelectAsync(new NetworkCommentSelectDto { });
            return new Response<NetworkComment>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/networkcommentsingle")]
        public async Task<Response<NetworkComment>> Get([FromQuery] NetworkCommentSelectDto Model)
        {
            Response<NetworkComment> Response = await Service.SelectSingleAsync(Model);
            return new Response<NetworkComment>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
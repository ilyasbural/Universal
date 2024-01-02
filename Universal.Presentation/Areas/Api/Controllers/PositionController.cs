namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class PositionController : ControllerBase
    {
        readonly IPositionService Service;
        public PositionController(IPositionService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/position")]
        public async Task<Response<Position>> Create([FromBody] PositionRegisterDto Model)
        {
            Response<Position> Response = await Service.InsertAsync(Model);
            return new Response<Position>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/position")]
        public async Task<Response<Position>> Update([FromBody] PositionUpdateDto Model)
        {
            Response<Position> Response = await Service.UpdateAsync(Model);
            return new Response<Position>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/position")]
        public async Task<Response<Position>> Delete([FromBody] PositionDeleteDto Model)
        {
            Response<Position> Response = await Service.DeleteAsync(Model);
            return new Response<Position>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        //[HttpPut]
        //[Route("api/position")]
        //public async Task<PositionWebResponse> Update([FromBody] PositionUpdateDataTransfer Model)
        //{
        //    PositionServiceResponse positionServiceResponse = await Service.UpdateAsync(Model);
        //    return new PositionWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/position")]
        //public async Task<PositionWebResponse> Delete([FromBody] PositionDeleteDataTransfer Model)
        //{
        //    PositionServiceResponse positionServiceResponse = await Service.DeleteAsync(Model);
        //    return new PositionWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/position")]
        public async Task<Response<Position>> Get()
        {
            Response<Position> Response = await Service.SelectAsync(new PositionSelectDto { });
            return new Response<Position>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/position/{id}")]
        //public async Task<PositionWebResponse> Get([FromBody] PositionAnyDataTransfer Model)
        //{
        //    PositionServiceResponse positionServiceResponse = await Service.AnySelectAsync(Model);
        //    return new PositionWebResponse
        //    {


        //    };
        //}
    }
}
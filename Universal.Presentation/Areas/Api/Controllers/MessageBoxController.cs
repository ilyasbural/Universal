namespace Universal.Api.Controllers
{
    using Core;
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
        public async Task<Response<MessageBox>> Create([FromBody] MessageBoxRegisterDto Model)
        {
            Response<MessageBox> Response = await Service.InsertAsync(Model);
            return new Response<MessageBox>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        //[HttpPut]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Update([FromBody] AbilityUpdateDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.UpdateAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Delete([FromBody] AbilityDeleteDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.DeleteAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/messagebox")]
        public async Task<Response<MessageBox>> Get()
        {
            Response<MessageBox> Response = await Service.SelectAsync();
            return new Response<MessageBox>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/ability/{id}")]
        //public async Task<AbilityWebResponse> Get([FromBody] AbilityAnyDataTransfer Model)
        //{
        //    AbilityServiceResponse announceResponse = await Service.AnySelectAsync(Model);
        //    return new AbilityWebResponse
        //    {


        //    };
        //}
    }
}
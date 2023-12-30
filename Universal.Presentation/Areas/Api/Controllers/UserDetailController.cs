namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserDetailController : ControllerBase
    {
        readonly IUserDetailService Service;
        public UserDetailController(IUserDetailService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/userdetail")]
        public async Task<Response<UserDetail>> Create([FromBody] UserDetailRegisterDto Model)
        {
            Response<UserDetail> Response = await Service.InsertAsync(Model);
            return new Response<UserDetail>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        //[HttpPut]
        //[Route("api/userdetail")]
        //public async Task<UserDetailWebResponse> Update([FromBody] UserDetailUpdateDataTransfer Model)
        //{
        //    UserDetailServiceResponse userDetailServiceResponse = await Service.UpdateAsync(Model);
        //    return new UserDetailWebResponse
        //    {
        //        Single = userDetailServiceResponse.Single,
        //        Success = userDetailServiceResponse.Success
        //    };
        //}

        //[HttpDelete]
        //[Route("api/userdetail")]
        //public async Task<UserDetailWebResponse> Delete([FromBody] UserDetailDeleteDataTransfer Model)
        //{
        //    UserDetailServiceResponse userDetailServiceResponse = await Service.DeleteAsync(Model);
        //    return new UserDetailWebResponse
        //    {
        //        Single = userDetailServiceResponse.Single,
        //        Success = userDetailServiceResponse.Success
        //    };
        //}

        [HttpGet]
        [Route("api/userdetail")]
        public async Task<Response<UserDetail>> Get()
        {
            Response<UserDetail> Response = await Service.SelectAsync();
            return new Response<UserDetail>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/userdetail/{id}")]
        //public async Task<UserDetailWebResponse> Get([FromBody] UserDetailAnyDataTransfer Model)
        //{
        //    UserDetailServiceResponse userDetailServiceResponse = await Service.AnySelectAsync(Model);
        //    return new UserDetailWebResponse
        //    {
        //        Success = userDetailServiceResponse.Success
        //    };
        //}
    }
}
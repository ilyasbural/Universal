namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserCertificateController : ControllerBase
    {
        readonly IUserCertificateService Service;
        public UserCertificateController(IUserCertificateService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/usercertificate")]
        public async Task<Response<UserCertificate>> Create([FromBody] UserCertificateRegisterDto Model)
        {
            Response<UserCertificate> Response = await Service.InsertAsync(Model);
            return new Response<UserCertificate>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        //[HttpPut]
        //[Route("api/usercertificate")]
        //public async Task<UserCertificateWebResponse> Update([FromBody] UserCertificateUpdateDataTransfer Model)
        //{
        //    UserCertificateServiceResponse userCertificateServiceResponse = await Service.UpdateAsync(Model);
        //    return new UserCertificateWebResponse
        //    {


        //    };
        //}

        //[HttpDelete]
        //[Route("api/usercertificate")]
        //public async Task<UserCertificateWebResponse> Delete([FromBody] UserCertificateDeleteDataTransfer Model)
        //{
        //    UserCertificateServiceResponse userCertificateServiceResponse = await Service.DeleteAsync(Model);
        //    return new UserCertificateWebResponse
        //    {


        //    };
        //}

        [HttpGet]
        [Route("api/usercertificate")]
        public async Task<Response<UserCertificate>> Get()
        {
            Response<UserCertificate> Response = await Service.SelectAsync();
            return new Response<UserCertificate>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/usercertificate/{id}")]
        //public async Task<UserCertificateWebResponse> Get([FromBody] UserCertificateAnyDataTransfer Model)
        //{
        //    UserCertificateServiceResponse userCertificateServiceResponse = await Service.AnySelectAsync(Model);
        //    return new UserCertificateWebResponse
        //    {


        //    };
        //}
    }
}
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

        [HttpPut]
        [Route("api/usercertificate")]
        public async Task<Response<UserCertificate>> Update([FromBody] UserCertificateUpdateDto Model)
        {
            Response<UserCertificate> Response = await Service.UpdateAsync(Model);
            return new Response<UserCertificate>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/usercertificate")]
        public async Task<Response<UserCertificate>> Delete([FromBody] UserCertificateDeleteDto Model)
        {
            Response<UserCertificate> Response = await Service.DeleteAsync(Model);
            return new Response<UserCertificate>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usercertificate")]
        public async Task<Response<UserCertificate>> Get()
        {
            Response<UserCertificate> Response = await Service.SelectAsync(new UserCertificateSelectDto { });
            return new Response<UserCertificate>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usercertificatesingle")]
        public async Task<Response<UserCertificate>> Get([FromQuery] UserCertificateSelectDto Model)
        {
            Response<UserCertificate> Response = await Service.SelectSingleAsync(Model);
            return new Response<UserCertificate>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [Area("api")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        readonly ICertificateService Service;
        public CertificateController(ICertificateService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/certificate")]
        public async Task<Response<Certificate>> Create([FromBody] CertificateRegisterDto Model)
        {
            Response<Certificate> Response = await Service.InsertAsync(Model);
            return new Response<Certificate>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/certificate")]
        public async Task<Response<Certificate>> Update([FromBody] CertificateUpdateDto Model)
        {
            Response<Certificate> Response = await Service.UpdateAsync(Model);
            return new Response<Certificate>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/certificate")]
        public async Task<Response<Certificate>> Delete([FromBody] CertificateDeleteDto Model)
        {
            Response<Certificate> Response = await Service.DeleteAsync(Model);
            return new Response<Certificate>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/certificate")]
        public async Task<Response<Certificate>> Get()
        {
            Response<Certificate> Response = await Service.SelectAsync(new CertificateSelectDto { });
            return new Response<Certificate>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/certificatesingle")]
        public async Task<Response<Certificate>> Get([FromQuery] CertificateSelectDto Model)
        {
            Response<Certificate> Response = await Service.SelectSingleAsync(Model);
            return new Response<Certificate>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }
    }
}
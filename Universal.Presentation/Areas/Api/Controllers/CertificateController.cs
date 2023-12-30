namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

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

        //[HttpPut]
        //[Route("api/certificate")]
        //public async Task<CertificateWebResponse> Update([FromBody] CertificateUpdateDataTransfer Model)
        //{
        //    CertificateServiceResponse certificateServiceResponse = await Service.UpdateAsync(Model);
        //    return new CertificateWebResponse
        //    {
        //        Single = certificateServiceResponse.Single,
        //        Success = certificateServiceResponse.Success
        //    };
        //}

        //[HttpDelete]
        //[Route("api/certificate")]
        //public async Task<CertificateWebResponse> Delete([FromBody] CertificateDeleteDataTransfer Model)
        //{
        //    CertificateServiceResponse certificateServiceResponse = await Service.DeleteAsync(Model);
        //    return new CertificateWebResponse
        //    {
        //        Single = certificateServiceResponse.Single,
        //        Success = certificateServiceResponse.Success
        //    };
        //}

        [HttpGet]
        [Route("api/certificate")]
        public async Task<Response<Certificate>> Get()
        {
            Response<Certificate> Response = await Service.SelectAsync();
            return new Response<Certificate>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/certificate/{id}")]
        //public async Task<CertificateWebResponse> Get([FromBody] CertificateAnyDataTransfer Model)
        //{
        //    CertificateServiceResponse certificateServiceResponse = await Service.AnySelectAsync(Model);
        //    return new CertificateWebResponse
        //    {
        //        Single = certificateServiceResponse.Single,
        //        Success = certificateServiceResponse.Success
        //    };
        //}
    }
}
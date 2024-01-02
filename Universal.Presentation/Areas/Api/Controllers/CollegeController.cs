namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class CollegeController : ControllerBase
    {
        readonly ICollegeService Service;
        public CollegeController(ICollegeService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/college")]
        public async Task<Response<College>> Create([FromBody] CollegeRegisterDto Model)
        {
            Response<College> Response = await Service.InsertAsync(Model);
            return new Response<College>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/college")]
        public async Task<Response<College>> Update([FromBody] CollegeUpdateDto Model)
        {
            Response<College> Response = await Service.UpdateAsync(Model);
            return new Response<College>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/college")]
        public async Task<Response<College>> Delete([FromBody] CollegeDeleteDto Model)
        {
            Response<College> Response = await Service.DeleteAsync(Model);
            return new Response<College>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/college")]
        public async Task<Response<College>> Get()
        {
            Response<College> Response = await Service.SelectAsync(new CollegeSelectDto { });
            return new Response<College>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/college/{id}")]
        //public async Task<CollegeWebResponse> Get([FromBody] CollegeAnyDataTransfer Model)
        //{
        //    CollegeServiceResponse collegeServiceResponse = await Service.AnySelectAsync(Model);
        //    return new CollegeWebResponse
        //    {
        //        Single = collegeServiceResponse.Single,
        //        Success = collegeServiceResponse.Success
        //    };
        //}
    }
}
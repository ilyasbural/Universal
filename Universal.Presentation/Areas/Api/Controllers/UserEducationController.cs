namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class UserEducationController : ControllerBase
    {
        readonly IUserEducationService Service;
        public UserEducationController(IUserEducationService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/usereducation")]
        public async Task<Response<UserEducation>> Create([FromBody] UserEducationRegisterDto Model)
        {
            Response<UserEducation> Response = await Service.InsertAsync(Model);
            return new Response<UserEducation>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/usereducation")]
        public async Task<Response<UserEducation>> Update([FromBody] UserEducationUpdateDto Model)
        {
            Response<UserEducation> Response = await Service.UpdateAsync(Model);
            return new Response<UserEducation>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/usereducation")]
        public async Task<Response<UserEducation>> Delete([FromBody] UserEducationDeleteDto Model)
        {
            Response<UserEducation> Response = await Service.DeleteAsync(Model);
            return new Response<UserEducation>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/usereducation")]
        public async Task<Response<UserEducation>> Get()
        {
            Response<UserEducation> Response = await Service.SelectAsync(new UserEducationSelectDto { });
            return new Response<UserEducation>
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
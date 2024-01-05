namespace Universal.Api.Controllers
{
    using Core;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    public class AbilityController : ControllerBase
    {
        readonly IAbilityService Service;
        public AbilityController(IAbilityService service)
        {
            Service = service;
        }

        [HttpPost]
        [Route("api/ability")]
        public async Task<Response<Ability>> Create([FromBody] AbilityRegisterDto Model)
        {
            Response<Ability> Response = await Service.InsertAsync(Model);
            return new Response<Ability>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpPut]
        [Route("api/ability")]
        public async Task<Response<Ability>> Update([FromBody] AbilityUpdateDto Model)
        {
            Response<Ability> Response = await Service.UpdateAsync(Model);
            return new Response<Ability>
            {
                Data = Response.Data,
                Success = Response.Success
            };
        }

        [HttpDelete]
        [Route("api/ability")]
        public async Task<Response<Ability>> Delete([FromBody] AbilityDeleteDto Model)
        {
            Response<Ability> Response = await Service.DeleteAsync(Model);
            return new Response<Ability>
            {
                Data = Response.Data, 
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/ability")]
        public async Task<Response<Ability>> Get()
        {
            Response<Ability> Response = await Service.SelectAsync(new AbilitySelectDto { });
            return new Response<Ability>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        [HttpGet]
        [Route("api/abilitysingle")]
        public async Task<Response<Ability>> Get([FromQuery] AbilitySelectDto Model)
        {
            Response<Ability> Response = await Service.SelectSingleAsync(Model);
            return new Response<Ability>
            {
                Collection = Response.Collection, 
                Success = Response.Success
            };
        }
    }
}
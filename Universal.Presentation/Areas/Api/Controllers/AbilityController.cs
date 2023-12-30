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

        //[HttpPut]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Update([FromBody] AbilityUpdateDataTransfer Model)
        //{
        //    AbilityServiceResponse abilityServiceResponse = await Service.UpdateAsync(Model);
        //    return new AbilityWebResponse
        //    {
        //        Single = abilityServiceResponse.Single, 
        //        Success = abilityServiceResponse.Success
        //    };
        //}

        //[HttpDelete]
        //[Route("api/ability")]
        //public async Task<AbilityWebResponse> Delete([FromBody] AbilityDeleteDataTransfer Model)
        //{
        //    AbilityServiceResponse abilityServiceResponse = await Service.DeleteAsync(Model);
        //    return new AbilityWebResponse
        //    {
        //        Single = abilityServiceResponse.Single,
        //        Success = abilityServiceResponse.Success
        //    };
        //}

        [HttpGet]
        [Route("api/ability")]
        public async Task<Response<Ability>> Get()
        {
            Response<Ability> Response = await Service.SelectAsync();
            return new Response<Ability>
            {
                Collection = Response.Collection,
                Success = Response.Success
            };
        }

        //[HttpGet]
        //[Route("api/ability/{id}")]
        //public async Task<AbilityWebResponse> Get([FromBody] AbilityAnyDataTransfer Model)
        //{
        //    AbilityServiceResponse abilityServiceResponse = await Service.AnySelectAsync(Model);
        //    return new AbilityWebResponse
        //    {
        //        Single = abilityServiceResponse.Single,
        //        Success = abilityServiceResponse.Success
        //    };
        //}
    }
}
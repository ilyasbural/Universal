namespace Universal.Presentation.Controllers
{
	using Core;
	using Common;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.Authorization;

	[ApiController]
    public class AnnounceController : ControllerBase
    {
        readonly IOrganizationBudgetService Service;

        public AnnounceController(IOrganizationBudgetService service)
        {
            Service = service;
        }

        //[HttpGet]
        //[Authorize]
        //[Route("api/organizationbudget")]
        //public async Task<Response<OrganizationBudgetResponse>> Get([FromQuery] OrganizationBudgetSelectDto Model)
        //{
        //    Response<OrganizationBudgetResponse> Response = await Service.SelectAsync(Model);
        //    return new Response<OrganizationBudgetResponse>
        //    {
        //        Collection = Response.Collection
        //    };
        //}
    }
}
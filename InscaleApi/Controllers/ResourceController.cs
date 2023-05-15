using InscaleApi.DataBase;
using InscaleApi.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace InscaleApi.Controllers
{
    [ApiController]
    [Route("api/resource")]
    
    public class ResourceController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetResources()
        {
            var resourceService = new ResourceServices(StaticDB.ResourcesDb);
            var resources = resourceService.GetAllResources();
            return new JsonResult(resources);
        }
    }
}

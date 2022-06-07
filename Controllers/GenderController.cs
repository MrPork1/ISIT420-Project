using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenderController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<GenderTable> Get()
        {
            var context = new Models.SocialDBContext();
            return context.GenderTables.ToList();
        }
    }
}

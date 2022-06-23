using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgeController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<AgeTable> Get()
        {
            var context = new Models.SocialDBContext();

            return context.AgeTables.ToList();
        }
    }
}
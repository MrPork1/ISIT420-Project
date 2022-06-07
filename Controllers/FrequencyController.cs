using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<FrequencyTable> Get()
        {
            var context = new Models.SocialDBContext();
            return context.FrequencyTables.ToList();
        }
    }
}

using Microsoft.AspNetCore.Http;
using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SecondQueryController : Controller
    {
        [HttpGet]
        public List<Data> Get()
        {
            var context = new Models.SocialDBContext();


            var paticipationQuery = context.ParticipationTables.GroupBy(r => r.GenderId, p => p.Percentage).Select(r => new
            {
                GenderId = r.Key,
                Percentage = r.Average()
            });

            var genderQuery = from joined1 in context.GenderTables
                              join joined2  in paticipationQuery on joined1.GenderId equals joined2.GenderId
                                 select new Data
                                 {
                                     Gender = joined1.Gender,
                                     Percentage = Math.Round((double)joined2.Percentage, 2)
                                 };
          


            var result2 = genderQuery.ToList();

            return result2;
        }
    }

    public class Data
    {
        public string Gender { get; set; }
        public double Percentage { get; set; }
    }
}
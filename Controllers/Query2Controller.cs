using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class Query2Controller : Controller
    {
        [HttpGet]
        public void Get()
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.FriendsTables
                            select each;
            var result = mainQuery.ToList();

            var secondQuery = from each in context.FriendsTables
                              where each.FrequencyId == 2 || each.FrequencyId == 5 || each.FrequencyId == 6
                              select each;

            var result2 = secondQuery.ToList();


            var averageByRegion = result.GroupBy(r => r.Gender, p => p.Percentage).Select(r => new
            {
                Gender = r.Key,
                Percentage = r.Average()
            });

            foreach (var item in averageByRegion)
            {
                Debug.WriteLine("Gender: " + item.Gender + " Percentage: " + item.Percentage);
            }
        }
    }

    public class Data
    {
        public string Region { get; set; }
        public double Percentage1 { get; set; }
        public double Percentage2 { get; set; }
        public double Percentage3 { get; set; }
    }
}

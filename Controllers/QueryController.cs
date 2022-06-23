using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Diagnostics;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class QueryController : Controller
    {
        //Did people who saw their friends a few times a month participate more in sports and cultural activities?
        [HttpGet]
        public List<ParticipationData> Get()
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.ParticipationTables
                        select each;
            var result = mainQuery.ToList();


            var averageByRegion = result.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });

            //A few times a month or more
            var friendsTableFrequency = from each in context.FriendsTables
                              where each.FrequencyId == 2 || each.FrequencyId == 5 || each.FrequencyId == 6
                              select each;

            var friendsTableFrequencyResult = friendsTableFrequency.ToList();

            var friendsTableAverageByRegionPercentage = friendsTableFrequency.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });

            //Less than a few times a month
            var friendsTableFrequency2 = from each in context.FriendsTables
                              where each.FrequencyId == 1 || each.FrequencyId == 3 || each.FrequencyId == 4 || each.FrequencyId == 7
                              select each;

            var averageByLessFrequencies = friendsTableFrequency2.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });

            //Inner join on region
            var innerJoinQuery = from avgRegion in averageByRegion
                                 join per in friendsTableAverageByRegionPercentage on avgRegion.Region equals per.Region
                                 join less in averageByLessFrequencies on per.Region equals less.Region
                                 select new ParticipationData
                                 {
                                     Region = avgRegion.Region,
                                     Percentage1 = (Math.Round((double)per.Percentage/100*(double)avgRegion.Percentage, 2)),
                                     Percentage2 = (Math.Round((double)less.Percentage/100*(double)avgRegion.Percentage, 2))
                                 };

            var newList = innerJoinQuery.ToList();
            return newList;
        }

        // GET: QueryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // GET: QueryController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }
    }

    public class ParticipationData
    {
        public string Region { get; set; }
        public double Percentage1 { get; set; }
        public double Percentage2 { get; set; }
        public double Percentage3 { get; set; }
    }
}

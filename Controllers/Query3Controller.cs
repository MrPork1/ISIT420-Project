using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISIT420_Project.Models;
using System.Diagnostics;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class Query3Controller : Controller
    {
        [HttpGet]
        public RegionData2 Get()
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

            var result1 = averageByRegion.OrderByDescending(a => a.Percentage);

            var mainResult = averageByRegion.OrderByDescending(a => a.Percentage).ToList();

            RegionData2 newRegionData = new RegionData2();
            newRegionData.Region = mainResult[0].Region;
            newRegionData.Percentage = (double)mainResult[0].Percentage;

            return newRegionData;
        }

        [HttpGet("{id}")]
        public string Get(string id)
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.ParticipationTables
                            select each;
            var result = mainQuery.ToList();
            Debug.WriteLine(id);
            var query = (from eachCountEvent in context.ParticipationTables
                         where eachCountEvent.Region == id
                         select new
                         {
                             eachCountEvent.Region,
                             eachCountEvent.Percentage
                         });
            
            var averageByRegion = query.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });

            var list = averageByRegion.ToList();
            RegionData2 newRegionData = new RegionData2();
            newRegionData.Region = list[0].Region;
            newRegionData.Percentage = (double)list[0].Percentage;
            Debug.WriteLine(list[0].Region);


            if (query != null)
            {
                return newRegionData.Region + " " + newRegionData.Percentage;
            }
            else
            {
                return "no id";
            }
        }
    }
    public class RegionData2
    {
        public string Region { get; set; }
        public double Percentage { get; set; }
    }
}

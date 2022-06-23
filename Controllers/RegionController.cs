using Microsoft.AspNetCore.Http;
using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<RegionData> Get()
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.ParticipationTables
                            select each;
            var result = mainQuery.ToList();

            var averageByRegion = result.GroupBy(r => r.Region).Select(r => new
            {
                Region = r.Key
            });

            var newList = averageByRegion.OrderBy(a => a.Region).ToList();
            //var newList = averageByRegion.ToList();

            List<RegionData> regionList = new List<RegionData>();

            for (int i = 0; i < newList.Count; i++)
            {
                RegionData newData = new RegionData();
                newData.Id = i;
                newData.Region = newList[i].Region;
                regionList.Add(newData);
            }

            return regionList;
        }
    }

    public class RegionData
    {
        public int Id { get; set; }

        public string Region { get; set; }
    }
}

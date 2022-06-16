using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISIT420_Project.Models;
using System.Diagnostics;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class Query4Controller : Controller
    {
        [HttpGet("{id}/{id2}")]
        public List<Query4Data> Get(string id, string id2)
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.FriendsTables
                            where each.FrequencyId == Convert.ToInt32(id2) && each.Region == id
                            select new Query4Data
                            {
                                Region = each.Region,
                                Percentage = (double)each.Percentage,
                                GenderId = (int)each.GenderId
                            };


            var genderQuery = from each in context.GenderTables
                              select each;

            var result = mainQuery.ToList();

            Debug.WriteLine(result[0].Region + result[0].Percentage);
            return result;
        }
    }

    public class Query4Data
    {
        public string Region { get; set; }
        public double Percentage { get; set; }
        public int GenderId { get; set; }
    }
}

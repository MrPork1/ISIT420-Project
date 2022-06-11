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
            var mainQuery = from each in context.ParticipationTables
                            select each;
            var result = mainQuery.ToList();


            var averageByRegion = result.GroupBy(r => r.GenderId, p => p.Percentage).Select(r => new
            {
                Gender = r.Key,
                Percentage = r.Average()
            });

            var result2 = averageByRegion.ToList();

            //foreach (var item in result2)
            //{
            //    Debug.WriteLine("Gender: " + item.Gender + " Percentage: " + item.Percentage);
            //}

            List<Data> list = new List<Data>();

            GenderTable genderTable = new GenderTable();


            foreach (var item in result2)
            {
                Data newData = new Data();
                newData.Gender = (int)item.Gender;
                newData.Percentage = (double)item.Percentage;
                list.Add(newData);
            }

            return list;
        }
    }

    public class Data
    {
        public int Gender { get; set; }
        public double Percentage { get; set; }
    }
}

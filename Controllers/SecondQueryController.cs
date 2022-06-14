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
                Gender = r.Key,
                Percentage = r.Average()
            });

            var genderQuery = from each in context.GenderTables
                              select each;

            //var mainQuery = from each in context.ParticipationTables
            //                join per in context.GenderTables on each.GenderId equals per.GenderId
            //                select each;
            //var result = mainQuery.ToList();

            var innerJoinQuery = from joined1 in paticipationQuery
                                 join joined2 in genderQuery on joined1.Gender equals joined2.GenderId
                                 select new Data
                                 {
                                     Gender = joined2.Gender,
                                     Percentage = Math.Round((double)joined1.Percentage,2)
                                 };


            var result2 = innerJoinQuery.ToList();

            //foreach (var item in result2)
            //{
            //    Debug.WriteLine("Gender: " + item.Gender + " Percentage: " + item.Percentage);
            //}

            //List<Data> list = new List<Data>();

            ////GenderTable genderTable = new GenderTable();


            //foreach (var item in result2)
            //{
            //    Data newData = new Data();
            //    newData.Gender = (int)item.Gender;
            //    newData.Percentage = (double)item.Percentage;
            //    list.Add(newData);
            //}

            return result2;
        }
    }

    public class Data
    {
        public string Gender { get; set; }
        public double Percentage { get; set; }
    }
}

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
        [HttpGet]
        public List<ParticipationData> Get()
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.ParticipationTables
                        select each;
            var result = mainQuery.ToList();

            //var newQuery = from each in result
            //               group each by each.Region;

            //foreach (var item in newQuery)
            //{
            //    Debug.WriteLine(item.Key);
            //    //double newAverage = 0.0;
            //    //int count = 0;
            //    foreach (var p in item)
            //    {
            //        //count++;
            //        //newAverage += (double)p.Percentage;
            //        Debug.WriteLine(p.Percentage);
            //    }
            //    //double average = newAverage / count;
            //}


            var averageByRegion = result.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });


            //foreach (var p in averageByRegion)
            //{
            //    Debug.WriteLine(p.Region + " " + p.Percentage);
            //}

            var secondQuery = from each in context.FriendsTables
                              where each.FrequencyId == 2 || each.FrequencyId == 5 || each.FrequencyId == 6
                              select each;

            var result2 = secondQuery.ToList();

            var averageByFrequency = secondQuery.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });

            var thirdQuery = from each in context.FriendsTables
                              where each.FrequencyId == 1 || each.FrequencyId == 3 || each.FrequencyId == 4 || each.FrequencyId == 7
                              select each;

            var averageByLessFrequencies = thirdQuery.GroupBy(r => r.Region, p => p.Percentage).Select(r => new
            {
                Region = r.Key,
                Percentage = r.Average()
            });

            //foreach (var p in averageByFrequency)
            //{
            //    Debug.WriteLine(p.Region + " " + p.Percentage);
            //}

            //var innerJoinQuery = from avgRegion in averageByRegion
            //                     join per in averageByFrequency on avgRegion.Region equals per.Region
            //                     join less in averageByLessFrequencies on per.Region equals less.Region
            //                     select new ParticipationData
            //                     {
            //                         Region = avgRegion.Region,
            //                         Percentage1 = (double)avgRegion.Percentage,
            //                         Percentage2 = (double)per.Percentage,
            //                         Percentage3 = (double)less.Percentage
            //                     };

            //foreach (var p in innerJoinQuery)
            //{
            //    Debug.WriteLine(p.Region + " " + p.Percentage1 + " " + p.Percentage2 + " " + p.Percentage3);
            //}

            //var newList = innerJoinQuery.ToList();
            //return newList;

            var innerJoinQuery = from avgRegion in averageByRegion
                                 join per in averageByFrequency on avgRegion.Region equals per.Region
                                 join less in averageByLessFrequencies on per.Region equals less.Region
                                 select new ParticipationData
                                 {
                                     Region = avgRegion.Region,
                                     Percentage1 = (double)(per.Percentage/100)*((double)avgRegion.Percentage),
                                     Percentage2 = (double)(less.Percentage/100)*(double)avgRegion.Percentage
                                 };

            foreach (var p in innerJoinQuery)
            {
                Debug.WriteLine(p.Region + " " + p.Percentage1 + " " + p.Percentage2 + " " + p.Percentage3);
            }

            var newList = innerJoinQuery.ToList();
            return newList;


            //
            //return averageByRegion.ToList();


            //var query = (from eachCountEvent in context.ParticipationTables
            //             where eachCountEvent.FrequencyId == 7
            //             group eachCountEvent by eachCountEvent.Region, eachCountEvent.Percentage into i
            //             select new ParticipationData
            //             {
            //                 Region = i.Key,
            //             });

            //var result1 = query.OrderByDescending(a => a.Percentage);
            //return query.ToList();
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

using ISIT420_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ISIT420_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrequencyController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<FrequencyData> Get()
        {
            var context = new Models.SocialDBContext();
            var mainQuery = from each in context.FrequencyTables
                            select each;
            var result = mainQuery.ToList();
            //return context.FrequencyTables.ToList();

            List<FrequencyData> frequencyList = new List<FrequencyData>();

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i].FrequencyId != 7)
                {
                    FrequencyData frequency = new FrequencyData();
                    frequency.Id = result[i].FrequencyId;
                    frequency.Frequency = result[i].Frequency;
                    frequencyList.Add(frequency);
                }
            }
            Debug.WriteLine(frequencyList[0].Frequency + " " + frequencyList[0].Id);

            return frequencyList;
        }
    }

    public class FrequencyData
    {
        public int Id { get; set; }

        public string Frequency { get; set; }
    }
}

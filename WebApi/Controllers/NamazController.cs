using LisansProje.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WebApi.Models;
using RestSharp;

namespace WebApi.Controllers
{
    public class NamazController : ApiControllerBase
    {
        private readonly Context _context;

        public NamazController(Context context)
        {
            _context = context;
        }

        [HttpGet("GetNamazData")]
        public async Task<IActionResult> GetNamazData()
        {
            //var client = new RestClient("https://api.collectapi.com/pray/all?data.city=istanbul");
            //var request = new RestRequest("/pray/all", RestSharp.Method.Get);
            //request.AddHeader("authorization", "apikey 5bTdo0WZYrXGjBFKcZ7ns5:2HpOZcqKA6ukJzC8RV5S9r");
            //request.AddHeader("content-type", "application/json");
            //var response = await client.ExecuteAsync<List<Root>>(request);

            //var client = new RestClient("https://api.collectapi.com/pray/all?data.city=istanbul");
            //var request = new RestRequest(Method.GET);
            //request.AddHeader("authorization", "apikey 5bTdo0WZYrXGjBFKcZ7ns5:2HpOZcqKA6ukJzC8RV5S9r");
            //request.AddHeader("content-type", "application/json");
            //IRestResponse response = client.Execute(request);

            var client = new RestClient("https://api.collectapi.com/pray/all?data.city=istanbul");
            var request = new RestRequest(Method.Get.ToString());
            request.AddHeader("authorization", "apikey 5bTdo0WZYrXGjBFKcZ7ns5:2HpOZcqKA6ukJzC8RV5S9r");
            request.AddHeader("content-type", "application/json");
            var response = await client.ExecuteAsync<List<Root>>(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                List<Namaz> namazList = new List<Namaz>();

                foreach (var root in response.Data)
                {
                    var namaz = new Namaz
                    {
                        SEHIR = "İstanbul",
                        TARIH = DateTime.Now.ToString(),
                        IMSAK = root.result[0].saat,
                        GUNES = root.result[1].saat,
                        OGLEN = root.result[2].saat,
                        IKINDI = root.result[3].saat,
                        AKSAM = root.result[4].saat,
                        YATSI = root.result[5].saat
                    };
                    namazList.Add(namaz);
                }                
                _context.NamazVakitleri.AddRange(namazList);
                await _context.SaveChangesAsync();
                return Ok(namazList);
            }
            else
            {
                return StatusCode((int)response.StatusCode);
            }
        }
    }
}

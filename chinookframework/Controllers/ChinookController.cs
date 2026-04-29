using chinookframework.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace chinookframework.Controllers
{
    public class ChinookController: Controller
    {
        static readonly HttpClient client = new HttpClient();

        public async Task<ActionResult> Index()
        {
            var response = await client.GetStringAsync(Environment.GetEnvironmentVariable("CHINOOKAPIURL"));
            var artists = JsonSerializer.Deserialize<IEnumerable<Artist>>(response);
            return View(artists);
        }
    }
}
using System.ComponentModel.Design;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace chinookmvc.Controllers;

public class ChinookController: Controller
{
    public async Task<ActionResult> Index()
    {
        string apiUrl = Environment.GetEnvironmentVariable("CHINOOKAPIURL");

        using(var client = new HttpClient())
        {
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            var response = await client.GetAsync(apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var table = Newtonsoft.Json.JsonConvert.DeserializeObject<System.Data.DataTable>(data);
                return View("Index",table);
            }
            else
            {
                throw new Exception(response.StatusCode + " " + response.Message);
            }
        }

        return View("Index",new System.Data.DataTable());
    }
}
using chinookapi.Models;
using Microsoft.AspNetCore.Mvc;

namespace chinookapi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ArtistsController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Artist> Get()
        {
            using(var ctx = new ChinookContext())
            {
                return ctx.Artists.ToList();
            }
        }
    }
}

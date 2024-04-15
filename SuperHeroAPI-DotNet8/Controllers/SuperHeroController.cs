using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_DotNet8.Entities;
using Microsoft.AspNetCore.Http;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<SuperHero>> GetAllHeroes()
        {
            var heroes = new List<SuperHero>
            {
                new SuperHero
                {
                    Id = 1,
                    Name = "Invincible",
                    FirstName = "Mark",
                    LastName = "Greyson",
                    Place = "Viltrum Earth"
            
                }
            };
            
            return Ok(heroes);
        }
    }  
}

using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using SuperHeroAPI_DotNet8.Data;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext _context;

        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();
            
            return Ok(heroes);
        }
        
        [HttpGet]
        [Route("GetOne")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return BadRequest("Hero not found");
            
            return Ok(hero);
        }
        
        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult<SuperHero>> AddHero(SuperHeroAddDto heroAdd)
        {
            SuperHero hero = new()
            {
                FirstName = heroAdd.Name,
                LastName = heroAdd.LastName,
                Name = heroAdd.Name,
                Place = heroAdd.Place
            };
            
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero hero)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(hero.Id);

            if (dbHero is null)
            {
                return NotFound("Hero not found.");
            }

            dbHero.Name = hero.Name;
            dbHero.FirstName = hero.FirstName;
            dbHero.LastName = hero.LastName;
            dbHero.Place = hero.Place;

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<SuperHero>> DeleteHero(int id)
        {
            var dbHero = await _context.SuperHeroes.FindAsync(id);

            if (dbHero is null)
            {
                return NotFound("Hero not found.");
            }

            _context.SuperHeroes.Remove(dbHero);

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());

        }
    }  
}

using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("GetAll")]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heroes = await _context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        [HttpGet("GetOne")]
        public async Task<ActionResult<SuperHero>> GetHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero is null)
                return BadRequest("Hero not found");

            return Ok(hero);
        }

        [HttpPost("AddHeroes")]
        public async Task<ActionResult<List<SuperHero>>> AddHeroes(List<SuperHeroAddDto> heroesAdd)
        {
            List<SuperHeroAddDto> NotFoundHeroes = new List<SuperHeroAddDto>();

            foreach (var heroAdd in heroesAdd)
            {
                if (await _context.Agencies.FindAsync(heroAdd.AgencyId) != null)
                {
                    NotFoundHeroes.Add(heroAdd);
                }
                else
                {
                    SuperHero hero = new()
                    {
                        FirstName = heroAdd.Name,
                        LastName = heroAdd.LastName,
                        Name = heroAdd.Name,
                        Place = heroAdd.Place,
                        AgencyId = heroAdd.AgencyId
                    };
                    _context.SuperHeroes.Add(hero);
                }
            }

            if (NotFoundHeroes.Count != 0)
            {
                return BadRequest($"Heroes with invalid agencies: {NotFoundHeroes}");
            }

            await _context.SaveChangesAsync();

            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpPut("Update")]
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

        [HttpDelete("Delete")]
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

        [HttpPost("addAgencies")]
        public async Task<ActionResult<List<Agency>>> AddAgencies(List<Agency> agencies)
        {
            foreach (var agency in agencies)
            {
                await _context.Agencies.AddAsync(agency);
            }

            _context.SaveChangesAsync();

            return Ok(await _context.Agencies.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Agency>> GetHeroesbyAgencyId(int id)
        {
            var dbAgency = await _context.Agencies.Include(c => c.SuperHeroes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (dbAgency is null)
            {
                return NotFound("Agency not found");
            }

            return Ok(dbAgency);
        }
    }
}
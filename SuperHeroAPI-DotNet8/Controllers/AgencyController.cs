using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SuperHeroAPI_DotNet8.Data;
using SuperHeroAPI_DotNet8.Entities;
using SuperHeroAPI_DotNet8.Entities.DTOs;
using SuperHeroAPI_DotNet8.Services;
using SuperHeroAPI_DotNet8.Services.Interfaces;

namespace SuperHeroAPI_DotNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly IConfiguration _config;
        private readonly ILoginService _loginService;

        public AgencyController(DataContext context, IConfiguration config, ILoginService loginService)
        {
            _context = context;
            _config = config;
            _loginService = loginService;
        }

        [HttpPut("Update")]
        [Authorize(Roles = "admin")]
        public async Task<ActionResult<Agency>> UpdateAgency(AgencyUpdateDto agency)
        {
            var dbAgency = await _context.Agencies.FindAsync(agency.Id);

            if (dbAgency is null)
            {
                return NotFound("Hero not found.");
            }

            dbAgency.Name = agency.Name;

            await _context.SaveChangesAsync();

            return Ok(await _context.Agencies.ToListAsync());
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Agency>> DeleteHero(int id)
        {
            var agency = await _context.Agencies.FindAsync(id);

            if (agency is null)
            {
                return NotFound("Hero not found.");
            }

            _context.Agencies.Remove(agency);

            await _context.SaveChangesAsync();

            return Ok(await _context.Agencies.ToListAsync());
        }

        [HttpPost("addAgencies")]
        public async Task<ActionResult<List<AgencyAddDto>>> AddAgencies(List<AgencyAddDto> agencies)
        {
            foreach (var agencyDto in agencies)
            {
                var agency = new Agency()
                {
                    Name = agencyDto.Name,
                    Password = agencyDto.Password,
                    Role = agencyDto.Role
                };

                await _context.Agencies.AddAsync(agency);
            }

            await _context.SaveChangesAsync();

            return Ok(await _context.Agencies.ToListAsync());
        }

        [HttpGet("GetAgency")]
        [Authorize(Roles = "Admin")]
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

        [HttpPost]
        public async Task<ActionResult<string>> Login(AgencyLoginDto agencyLoginDto)
        {
            var dbAgency = await _context.Agencies.FirstOrDefaultAsync(a => a.Name == agencyLoginDto.Name);

            if (dbAgency == null)
            {
                return Unauthorized();
            }

            if (dbAgency.Password != agencyLoginDto.Password)
            {
                return BadRequest("Wrong Password");
            }
            
            var token = _loginService.CreateToken(dbAgency);

            return Ok(token);
        }
    }
}
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using AutoMapper;
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
        private readonly ILoginService _loginService;
        private readonly IMapper _mapper;

        public AgencyController(DataContext context, ILoginService loginService, IMapper mapper)
        {
            _context = context;
            _loginService = loginService;
            _mapper = mapper;
        }

        [HttpPut("Update")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult<Agency>> UpdateAgency(AgencyUpdateDto agency)
        {
            var dbAgency = await _context.Agencies.FindAsync(agency.Id);

            if (dbAgency is null)
            {
                return NotFound("Hero not found.");
            }

            dbAgency.Name = agency.Name;
            dbAgency.Role = agency.Role;

            await _context.SaveChangesAsync();

            var agencies = _context.Agencies.Select(agency => _mapper.Map<AgencyUpdateDto>(agency));
            
            return Ok(agencies);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete")]
        public async Task<ActionResult<Agency>> DeleteAgency(int id)
        {
            var agency = await _context.Agencies.FindAsync(id);

            if (agency is null)
            {
                return NotFound("Agency not found.");
            }

            _context.Agencies.Remove(agency);

            await _context.SaveChangesAsync();

            var agencies = _context.Agencies.Select(agency => _mapper.Map<AgencyUpdateDto>(agency));
            
            return Ok(agencies);
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost("addAgencies")]
        public async Task<ActionResult<List<AgencyAddDto>>> AddAgencies(List<AgencyAddDto> agenciesAddDtos)
        {
            foreach (var agencyAddDto in agenciesAddDtos)
            {
                _context.Add(_mapper.Map<Agency>(agencyAddDto));
            }
            
            await _context.SaveChangesAsync();

            var agencies = _context.Agencies.Select(agency => _mapper.Map<Agency>(agency));
            
            return Ok(agencies);
        }

        [HttpGet("GetAgency")]
        public async Task<ActionResult<Agency>> GetAgencyById(int id)
        {
            var dbAgency = await _context.Agencies.Include(c => c.SuperHeroes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (dbAgency is null)
            {
                return NotFound("Agency not found");
            }

            var agencyOutput = _mapper.Map<AgencyUpdateDto>(dbAgency);

            return Ok(agencyOutput);
        }

        [HttpPost("Login")]
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
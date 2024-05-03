using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using SuperHeroAPI_DotNet8.Entities.DTOs;

namespace SuperHeroAPI_DotNet8.Entities;

public class Agency
{
    public int Id { get; set; }
    public string Name { get; set; }

    public string Password { get; set; }
    
    public string Role { get; set; }
    public List<SuperHero> SuperHeroes { get; set; }
}
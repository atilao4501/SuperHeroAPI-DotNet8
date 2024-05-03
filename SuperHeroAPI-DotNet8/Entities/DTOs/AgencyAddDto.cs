using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI_DotNet8.Entities.DTOs;

public class AgencyAddDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public string Role { get; set; }
    
}
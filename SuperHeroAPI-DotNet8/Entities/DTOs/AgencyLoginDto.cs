using System.ComponentModel.DataAnnotations;

namespace SuperHeroAPI_DotNet8.Entities.DTOs;

public class AgencyLoginDto
{
    [Required]
    public string Name { get; set; }
    
    [Required]
    public string Password { get; set; }
}
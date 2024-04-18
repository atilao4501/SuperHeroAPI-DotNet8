using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SuperHeroAPI_DotNet8.Entities.DTOs;

public class SuperHeroAddDto
{
    [Required(ErrorMessage = "The name field is required")]
    public string Name { get; set; } 
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Place { get; set; } = String.Empty;
}